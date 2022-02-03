using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace SmsTeknikLibraryExamples.Pages
{
    public class SendSingleMessageModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            string from = Request.Form["txtFrom"];
            string to = Request.Form["txtTo"];
            string body = Request.Form["txtBody"];

            if(from.Length == 0 || to.Length == 0 || body.Length == 0)
            {
                Message = "Required information missing";
                return;
            }

            var client = SMSTeknikClient.SmsTeknik.CreateClient(
               new SMSTeknikClient.Config.SmsTeknikConfiguration() { Username = "your username", Password = "your password" });

            try
            {
                var message = new SMSTeknikClient.Messages.OutgoingSmsMessage()
                {
                    Body = body,
                    From = from,
                    To = to
                };

                var response = await client.Send(message);

                if (response.Success)
                    Message = $"Your message was sent successfully! Message id: {response.SmsId}";
                else
                    Message = $"Failed with reason: {response.ErrorMessage}";

            }
            catch(Exception ex)
            {
                Message = $"Error sending sms. Reason: {ex.Message}";
            }

        }
    }
}
