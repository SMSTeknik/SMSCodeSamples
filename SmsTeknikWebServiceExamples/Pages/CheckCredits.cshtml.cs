using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikWebServiceExamples.Pages
{
    public class CheckCreditsModel : PageModel
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

            // Initialize the service
            var service = new se.smsteknik.utilities.UtilitiesSoapClient(se.smsteknik.utilities.UtilitiesSoapClient.EndpointConfiguration.UtilitiesSoap12);

            // Call the method
            var result = await service.CheckCreditsAsync(id, user, pass);
            
            // Write raw response to screen.
            RawResponse = result;

            if (result.StartsWith("0:"))
            {
                // Error
                Message = $"The server returned error: {result.Substring(2)}";
            }
            else
            {
                // Success!

                // If success the result should be an integer.
                int credits = Convert.ToInt32(result);
                
                Message = $"The request was successful! You have {credits} credits.";
            }
        }
    }
}
