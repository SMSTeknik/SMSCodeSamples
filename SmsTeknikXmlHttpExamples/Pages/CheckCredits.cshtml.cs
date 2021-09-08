using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class CheckCreditsModel : PageModel
    {
        public string Message { get; set; }
        public string RawResponse { get; set; }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic [your token]";

                var result = client.DownloadString(new Uri("https://api.smsteknik.se/utilities/checkcredits/"));

                // Write raw response to screen.
                RawResponse = result;

                if (result.StartsWith("0:"))
                {
                    // Failed.
                    Message = "Failed with reason: " + result.Substring(2);
                }
                else
                {

                    // If success the result should be an integer.
                    int credits = Convert.ToInt32(result);

                    Message = $"The request was successful! You have {credits} credits.";
                }

            }
        }
    }
}
