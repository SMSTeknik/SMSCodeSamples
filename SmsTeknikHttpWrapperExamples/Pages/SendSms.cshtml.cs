using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikHttpWrapperExamples.Pages
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
            string sender = HttpUtility.UrlEncode(Request.Form["txtSender"]);
            string recipient = Request.Form["txtRecipient"];
            string text = HttpUtility.UrlEncode(Request.Form["txtText"]);

            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic [your token]";

                var result = client.DownloadString($"https://api.smsteknik.se/send/?nr={recipient}&sender={sender}&msg={text}");

                // Write raw response to screen.
                RawResponse = result;

                if (result.StartsWith("0:"))
                {
                    // Failed.
                    Message = "SMS failed with reason: " + result.Substring(2);
                }
                else
                {
                    // Success
                    long smsid = Convert.ToInt64(result);
                    Message = "SMS successfully sent. SMS ID: " + smsid;
                }
            }

        }
    }
}
