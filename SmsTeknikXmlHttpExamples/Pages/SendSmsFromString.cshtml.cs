using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class SendSmsFromStringModel : PageModel
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

            // We are adding recipents to a collections to demonstrate how to generate the XML more dynamically.
            var recipients = new List<string>();
            if (!string.IsNullOrEmpty(recipient1))
                recipients.Add(recipient1);
            if (!string.IsNullOrEmpty(recipient2))
                recipients.Add(recipient2);

            var request = new StringBuilder();
            request.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            request.AppendLine("<sms-teknik>");
            request.AppendLine($"<udmessage><![CDATA[{text}]]></udmessage>");
            request.AppendLine($"<smssender>{sender}</smssender>");
            request.AppendLine("<items>");
            
            // Add recipients from collection
            foreach (var recipient in recipients)
                request.AppendLine($"<recipient><nr>{recipient}</nr></recipient>");
            
            request.AppendLine("</items>");
            request.AppendLine("</sms-teknik>");

            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic c21zOEEwOURDOjZjYzFkYWQ=";

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
    }
}
