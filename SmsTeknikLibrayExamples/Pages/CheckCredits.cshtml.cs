using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikLibrayExamples.Pages
{
    public class CheckCreditsModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {


            var client = SMSTeknikClient.SmsTeknik.CreateClient(
                new SMSTeknikClient.Config.SmsTeknikConfiguration() { Username = "your username", Password= "your password" });

            try
            {

                var credits = await client.CheckCredits();

                Message = $"The request was successful! You have {credits} credits.";

            }
            catch
            {
                Message = "Error checking credits.";
            }


        }
    }
}
