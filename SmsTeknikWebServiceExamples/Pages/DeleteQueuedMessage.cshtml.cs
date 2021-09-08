using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikWebServiceExamples.Pages
{
    public class DeleteQueuedMessageModel : PageModel
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

            // Get the stated smsid
            long smsid = Convert.ToInt64(Request.Form["txtSmsid"]);

            // Initialize the service
            var service = new se.smsteknik.utilities.UtilitiesSoapClient(se.smsteknik.utilities.UtilitiesSoapClient.EndpointConfiguration.UtilitiesSoap12);

            // Call the method
            var result = await service.DeleteQueuedSMSAsync(id, user, pass, smsid);

            // Write raw response to screen.
            RawResponse = result;

            if (result.StartsWith("0:"))
            {
                // Error
                Message = $"The server returned error: {result.Substring(2)}";
            }
            else
            {
                // No probmems so far. It now returns 0 if could not be removed, or 1 if removed from queue.

                if(result == "0")
                {
                    Message = "The SMS could not be removed or has been removed earlier";
                }
                else if(result == "1")
                {
                    Message = "Success! The SMS has been removed from the queue!";
                }
                
            }
        }
    }
}
