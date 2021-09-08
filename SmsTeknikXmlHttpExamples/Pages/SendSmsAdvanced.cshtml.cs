using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class SendSmsAdvancedModel : PageModel
    {
        public string Message { get; set; }
        public string RawResponse { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Get values from form.
            string sender = Request.Form["txtSender"];
            string recipient1 = Request.Form["txtRecipient1"];
            string recipient2 = Request.Form["txtRecipient2"];
            string text = Request.Form["txtText"];
            bool multiSms = Request.Form["cbMultiSMS"] == "on";
            string deliveryReportUrl = Request.Form["txtDeliveryReportUrl"];
            string customId = Request.Form["txtCustomId"];


            // 0=Text, 1=Wap-push, 2=vCard, 3=vCalender, 4=Binary, 5=Unicode, [int] 
            int operationType = 0;
            // 0=Normal message, 1=Flash message (160 char limit)
            int flash = 0;
            // Time to live. 0=Operation default, 30-840 minutes
            int ttl = 0;
            // Compress text to save space. Removes spaces and converts to upper camel case.
            int compressText = 0;
            // Schedule, must be on format yyyy-MM-dd (CET/CEST)
            string sendDate = "";
            // Schedule, must be on format HH:mm:ss (CET/CEST)
            string sendTime = "";
            // Type of delivery reports. In this case HTTP Get.
            int deliveryStatusType = 2;

            // Set delivery status type to 0 (none) if no URL stated in the form.
            if (deliveryReportUrl.Length == 0)
                deliveryStatusType = 0;

            // Add recipients to the collection.
            var recipients = new List<SmsRequestRecipient>();
            if (!string.IsNullOrEmpty(recipient1))
                recipients.Add(new SmsRequestRecipient() { Phonenumber = recipient1 });
            if (!string.IsNullOrEmpty(recipient2))
                recipients.Add(new SmsRequestRecipient() { Phonenumber = recipient2 });

            var request = new SmsRequest()
            {
                OperationType = operationType,
                Message = text,
                Sender = sender,
                Recipients = recipients,
                MultiSms = multiSms ? 1 : 0,
                MaxMultiSms = multiSms ? 6 : 0,
                CustomId = customId,
                CompressText = compressText,
                DeliveryStatusType = deliveryStatusType,
                DeliveryStatusAddress = deliveryReportUrl,
                Flash = flash,
                SendDate = sendDate,
                SendTime = sendTime,
                Ttl = ttl
            };

            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic [your token]";

                // Convert data to byte array. The ToString()-method serializes the object into an XML string.
                var data = System.Text.Encoding.UTF8.GetBytes(request.ToString());

                var returnData = client.UploadData(new Uri("https://api.smsteknik.se/send/xml/"), data);

                // Convert response from byte array to string.
                var result = System.Text.Encoding.Default.GetString(returnData);

                RawResponse = result;

                string[] arrResult = result.Split(';');

                foreach (var resultItem in arrResult)
                {
                    if (resultItem.StartsWith("0:"))
                    {
                        // Failed.
                        Message = "SMS failed with reason: " + resultItem.Substring(2);
                    }
                    else
                    {
                        // Success
                        long smsid = Convert.ToInt64(resultItem);
                        Message = "SMS successfully sent. SMS ID: " + smsid;
                    }
                }
            }

        }

        [Serializable]
        [XmlRoot("sms-teknik")]
        public class SmsRequest
        {
            [XmlElement("operationtype")]
            [DefaultValue(0)]
            public int OperationType { get; set; }

            [XmlElement("udmessage")]
            public string Message { get; set; }

            [XmlElement("smssender")]
            public string Sender { get; set; }

            [XmlElement("items")]
            public List<SmsRequestRecipient> Recipients { get; set; }

            [XmlElement("flash")]
            [DefaultValue(0)]
            public int Flash { get; set; }

            [XmlElement("multisms")]
            [DefaultValue(0)]
            public int MultiSms { get; set; }

            [XmlElement("maxmultisms")]
            [DefaultValue(0)]
            public int MaxMultiSms { get; set; }

            [XmlElement("ttl")]
            [DefaultValue(0)]
            public int Ttl { get; set; }

            [XmlElement("compresstext")]
            [DefaultValue(0)]
            public int CompressText { get; set; }

            [XmlElement("send_date")]
            [DefaultValue("")]
            public string SendDate { get; set; }

            [DefaultValue("")]
            [XmlElement("send_time")]
            public string SendTime { get; set; }

            [XmlElement("customid")]
            [DefaultValue("")]
            public string CustomId { get; set; }

            [DefaultValue(0)]
            [XmlElement("deliverystatustype")]
            public int DeliveryStatusType { get; set; }
            
            [XmlElement("deliverystatusaddress")]
            [DefaultValue("")]
            public string DeliveryStatusAddress { get; set; }

            public override string ToString()
            {
                // This method will serialize object into an XML string.

                var sb = new System.Text.StringBuilder();

                // We need UTF-8 encoding. Therefore this special handling.
                var stringWriter = new StringWriterWithEncoding(sb, System.Text.Encoding.UTF8);

                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.CloseOutput = true;

                var writer = XmlWriter.Create(stringWriter, settings);
                var xmlSerializer = new XmlSerializer(this.GetType());

                xmlSerializer.Serialize(writer, this);

                return sb.ToString();


            }
        }

        [XmlRoot("recipient")]
        public class SmsRequestRecipient
        {
            [XmlElement("nr")]
            public string Phonenumber { get; set; }
        }

        public class StringWriterWithEncoding : System.IO.StringWriter
        {
            public StringWriterWithEncoding(System.Text.StringBuilder sb, System.Text.Encoding encoding)
                : base(sb)
            {
                this.m_Encoding = encoding;
            }
            private readonly System.Text.Encoding m_Encoding;
            public override System.Text.Encoding Encoding
            {
                get
                {
                    return this.m_Encoding;
                }
            }
        }
    }
}
