using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class SendSmsModel : PageModel
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

            // Add recipients to the collection.
            var recipients = new List<SmsRequestRecipient>();
            if (!string.IsNullOrEmpty(recipient1))
                recipients.Add(new SmsRequestRecipient() { Phonenumber = recipient1 });
            if (!string.IsNullOrEmpty(recipient2))
                recipients.Add(new SmsRequestRecipient() { Phonenumber = recipient2 });

            var request = new SmsRequest()
            {
                Message = text,
                Sender = sender,
                Recipients = recipients
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
                
                // Write raw response to screen.
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
            [XmlElement("udmessage")]
            public string Message { get; set; }

            [XmlElement("smssender")]
            public string Sender { get; set; }

            [XmlElement("items")]
            public List<SmsRequestRecipient> Recipients { get; set; }

            public override string ToString()
            {
                // This method will serialize object into an XML string.

                var sb = new System.Text.StringBuilder();
                
                // We need UTF-8 encoding. Therefore this special handling.
                var stringWriter = new StringWriterWithEncoding(sb, System.Text.Encoding.UTF8);

                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.CloseOutput = true;

                XmlWriter writer = XmlWriter.Create(stringWriter, settings);
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
