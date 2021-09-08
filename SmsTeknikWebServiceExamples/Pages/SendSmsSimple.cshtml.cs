using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikWebServiceExamples.Pages
{
    public class SendSmsSimpleModel : PageModel
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
            string text = Request.Form["txtText"];
            bool multiSms = Request.Form["cbMultiSMS"] == "on";


            // Initialize the service
            var service = new se.smsteknik.SendSMSSoapClient(se.smsteknik.SendSMSSoapClient.EndpointConfiguration.SendSMSSoap12);

            // Call the method
            var result = await service.SendSMSSingleAsync(id, user, pass, multiSms ? 1 : 0, multiSms ? 6 : 1, text, sender, recipient);

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

                // If success the returning value is a smsid.
                long smsid = Convert.ToInt64(result);

                // Write a litte message with the smsid.
                Message = $"Success! This message received the following smsid: {smsid}";
            }
        }

    }
}
