using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikWebServiceExamples.Pages
{
    public class SendSmsMultiModel : PageModel
    {

        public string Message { get; set; }
        public string RawResponse { get; set; }


        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            string id = "[your id]";
            string user = "[your username]";
            string pass = "[your password]";

            // Get values from form.
            string sender = Request.Form["txtSender"];
            string recipient = Request.Form["txtRecipient"];
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

            // You can all multiple recipents.
            string[] recipients = new string[] { recipient, recipient2 };

            // Initialize the service
            var service = new se.smsteknik.SendSMSSoapClient(se.smsteknik.SendSMSSoapClient.EndpointConfiguration.SendSMSSoap12);

            // Call the method
            var result = await service.SendSMSMultiAsync(id, user, pass, operationType, flash, multiSms ? 1 : 0, multiSms ? 6 : 1, ttl, customId, compressText, sendDate, sendTime, text, "", sender, deliveryStatusType, deliveryReportUrl, 0, 0, "", "", recipients);

            // Write raw response to screen.
            RawResponse = result;

            if (result.StartsWith("0:"))
            {
                // Error. This is typically account errors. Errors for SMS is stated in the XML object.

                Message = $"The server returned error: {result.Substring(2)}";
            }
            else
            {
                // Success!

                // If success the response is an XML object containing status for each of the messages.
                var sendResponse = SendResponse.Deserialize(result);

                StringBuilder sbResult = new StringBuilder();

                // Check status for each of the messages
                foreach(var sms in sendResponse.Sms.smsid)
                {
                    if (sms.StartsWith("0:"))
                    {
                        sbResult.AppendLine($"Error {sms.Substring(2)}");
                    }
                    else
                    {
                        long smsId = Convert.ToInt64(sms);

                        sbResult.AppendLine($"Smsid: {smsId}");
                    }
                        
                }
                
                // Write a litte message just to show that we can use the serialized object.
                Message = $"Received response for {sendResponse.Sms.smsid.Count} messages. Details {sbResult.ToString()}.";
            }
        }
    }

    [Serializable]
    [XmlRoot("response")]
    public class SendResponse
    {
        [XmlElement(ElementName = "datetime")]
        public string DateTime { get; set; }
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }
        [XmlElement(ElementName = "smsleft")]
        public int SmsLeft { get; set; }
        [XmlElement(ElementName = "sms")]
        public SendResponseSms Sms { get; set; }


        public static SendResponse Deserialize(string xmlData)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SendResponse));
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(xmlData));

            return (SendResponse)serializer.Deserialize(reader);
        }
    }

    [Serializable]
    public class SendResponseSms
    {
        [XmlElement(ElementName = "smsid")]
        public List<string> smsid { get; set; }
    }
}
