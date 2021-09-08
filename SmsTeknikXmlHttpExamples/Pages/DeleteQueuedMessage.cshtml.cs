using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class DeleteQueuedMessageModel : PageModel
    {
        public string Message { get; set; }
        public string RawResponse { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Get the stated smsid
            long smsid = Convert.ToInt64(Request.Form["txtSmsid"]);

            var request = new StringBuilder();
            request.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            request.AppendLine("<sms-teknik>");
            request.AppendLine($"<smsid>{smsid}</smsid>");
            request.AppendLine("</sms-teknik>");

            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic c21zOEEwOURDOjZjYzFkYWQ=";

                // Convert data to byte array. The ToString()-method serializes the object into an XML string.
                var data = System.Text.Encoding.UTF8.GetBytes(request.ToString());

                var returnData = client.UploadData(new Uri("https://api.smsteknik.se/utilities/deletequeuedsms/"), data);

                // Convert response from byte array to string.
                var result = System.Text.Encoding.Default.GetString(returnData);

                // Write raw response to screen.
                RawResponse = result;


                if (result.StartsWith("0:"))
                {
                    // Failed.
                    Message = "SMS failed with reason: " + result.Substring(2);
                }
                else
                {
                    if (result == "0")
                    {
                        Message = "The SMS could not be removed or has been removed earlier";
                    }
                    else if (result == "1")
                    {
                        Message = "Success! The SMS has been removed from the queue!";
                    }

                }
           
            }
        }


    }
}
