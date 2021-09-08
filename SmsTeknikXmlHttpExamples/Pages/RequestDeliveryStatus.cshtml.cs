using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsTeknikXmlHttpExamples.Pages
{
    public class RequestDeliveryStatusModel : PageModel
    {
        public string Message { get; set; }
        public string RawResponse { get; set; }


        public void OnGet()
        {
        }

        public void OnPost()
        {
            string smsid1 = Request.Form["txtSmsid1"];
            string smsid2 = Request.Form["txtSmsid2"];


            // You can construct the request from string, or serialize an object to XML. See example "SendSmsAdvanced" and "SendSMS" for serializing.
            var request = new StringBuilder();
            request.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            request.AppendLine("<sms-teknik>");
            request.AppendLine($"<smsid>{smsid1}</smsid>");
            request.AppendLine($"<smsid>{smsid2}</smsid>");
            request.AppendLine("</sms-teknik>");

            using (var client = new System.Net.WebClient())
            {
                // It is recommended to use Basic Auth, but it is also possible to add credentials to URL.
                client.Headers["Authorization"] = "Basic [your token]";

                // Convert data to byte array. The ToString()-method serializes the object into an XML string.
                var data = System.Text.Encoding.UTF8.GetBytes(request.ToString());

                var returnData = client.UploadData(new Uri("https://api.smsteknik.se/utilities/getstatus/"), data);

                // Convert response from byte array to string.
                var result = System.Text.Encoding.Default.GetString(returnData);

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
        [XmlRoot("sms-teknik")]
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
            [XmlElement(ElementName = "customid")]
            public string CustomId { get; set; }

        }
    }
}
