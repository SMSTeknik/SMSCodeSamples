using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace SmsTeknikWebServiceExamples.Pages
{
    public class RequestDeliveryStatusModel : PageModel
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

            string smsid1 = Request.Form["txtSmsid1"];
            string smsid2 = Request.Form["txtSmsid2"];

            // You can add multiple smsid's to the array.
            var smsids = new string[] { smsid1, smsid2 };

            // Initialize the service
            var service = new se.smsteknik.utilities.UtilitiesSoapClient(se.smsteknik.utilities.UtilitiesSoapClient.EndpointConfiguration.UtilitiesSoap12);

            // Call the method
            var result = await service.RequestStatusAsync(id, user, pass, smsids);

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

                // Deserialize result (XML) into object.
                var deserializedObject = DeliveryStatusResponse.Deserialize(result);

                // Write a litte message just to show that we can use the serialized object.
                Message = $"Success! Object deserialized. Contains response for {deserializedObject.Items.Count()} messages.";
            }
        }

    }


    [Serializable]
    [XmlRoot("smsteknik")]
    public class DeliveryStatusResponse
    {

        [XmlElement(ElementName = "item")]
        public List<DeliveryStatusResponseItem> Items { get; set; }


        public static DeliveryStatusResponse Deserialize(string xmlData)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(DeliveryStatusResponse));
            var reader = System.Xml.XmlReader.Create(new System.IO.StringReader(xmlData));

            return (DeliveryStatusResponse)serializer.Deserialize(reader);
        }
    }

    public class DeliveryStatusResponseItem
    {

        [XmlElement(ElementName = "smsid")]
        public long SmsId { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "donedate")]
        public string DoneDate { get; set; }
    }

}
