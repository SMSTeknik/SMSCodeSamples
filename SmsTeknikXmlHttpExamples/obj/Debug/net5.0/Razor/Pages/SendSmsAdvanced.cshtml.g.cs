#pragma checksum "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "958a0ae032592d20eebfb0b933553653619d6182"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SmsTeknikXmlHttpExamples.Pages.Pages_SendSmsAdvanced), @"mvc.1.0.razor-page", @"/Pages/SendSmsAdvanced.cshtml")]
namespace SmsTeknikXmlHttpExamples.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\_ViewImports.cshtml"
using SmsTeknikXmlHttpExamples;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"958a0ae032592d20eebfb0b933553653619d6182", @"/Pages/SendSmsAdvanced.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ae29bda048aa02b4f117ac6ffd7666114417271", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SendSmsAdvanced : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
  
    ViewData["Title"] = "Send SMS Advanced";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div>
    <h1>Send SMS Advanced</h1>
    <p>This example has more properties and also configurates delivery reports.</p>

    <p>Available properties for this method:</p>
    <ul>
        <li><i>id</i>, <i>user</i> and <i>pass</i>: Credentials for your account</li>
        <li><i>smssender</i>: The sender as alphanumeric (eg. Test) or phone number starting with country prefix (eg. +4790000000)</li>
        <li><i>recipients</i>: Collection/list of receivers of the SMS (eg. +4790000000)</li>
        <li><i>multisms</i>: Value indicating if allowed to send more that one message part (length > 160)</li>
        <li><i>maxmultisms</i>: Number of allowed message parts</li>
        <li><i>text</i>: the content of the message</li>
        <li><i>ttl</i>: Time To Live. Sets the time that the SMS message is valid in the GSM network. Accepts a value of 0 or between 30 - 840 minutes. 0 means that the TTL is set to the operators default.</li>
        <li><i>operationtype:</i> 0=Text, 1=Wap-push, 2=vCard,");
            WriteLiteral(@" 3=vCalender, 4=Binary, 5=Unicode</li>
        <li><i>customid</i>: Lets you add your own identification (tag) for the submitted messages. This might help you keep track of your messages when you receive the delivery report</li>
        <li><i>send_date</i>: Date for scheduled message. Must be on format yyyy-MM-dd. Time zone CET/CEST.</li>
        <li><i>send_time</i>: Time for scheduled message. Must bon on format HH:mm:ss. Time zone CET/CEST.</li>
        <li><i>deliverystatustype</i>: Where to send the delivery report. 0 = Off, 1 = E-mail, 2 = http Get, 3 = http Post, 4 = HTTP XML</li>
        <li><i>deliverystatusaddress</i>: URL or E-mail address (based on setting in <i>deliverystatustype</i>)</li>
    </ul>

    <p>Some less important properties has been included from the above list. Se official documentation (or code behind) for å complete list.</p>

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "958a0ae032592d20eebfb0b933553653619d61825618", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"txtSender\">Sender</label>\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"Sender, ex Test or phone number\" name=\"txtSender\"");
                BeginWriteAttribute("value", " value=\"", 2251, "\"", 2259, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">Alphanumeric name or phone number (remember country prefix, eg. +4790000000.</small>
        </div>
        
        <div class=""form-group"">
            <label for=""txtRecipient1"">Recipient</label>
            <input type=""text"" class=""form-control"" placeholder=""Phone number"" name=""txtRecipient1""");
                BeginWriteAttribute("value", " value=\"", 2616, "\"", 2624, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">Phone number starting with country prefix, eg. +4790000000</small>
        </div>

        <div class=""form-group"">
            <label for=""txtRecipient2"">Additional recipient</label>
            <input type=""text"" class=""form-control"" placeholder=""Phone number"" name=""txtRecipient2""");
                BeginWriteAttribute("value", " value=\"", 2966, "\"", 2974, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">This is only to demonstrate that you can add multiple recipients in the same request.</small>
        </div>

        <div class=""form-group"">
            <label for=""txtText"">Text</label>
            <textarea class=""form-control"" name=""txtText"" rows=""3""></textarea>
            <small class=""form-text text-muted"">Remember to activate <i>multisms</i> and <i>maxmultisms</i> if more that 160 chars.</small>
        </div>


        <div class=""form-group"">
            <label for=""txtDeliveryReportUrl"">Delivery Report URL</label>
            <input type=""text"" class=""form-control"" placeholder=""URL"" name=""txtDeliveryReportUrl""");
                BeginWriteAttribute("value", " value=\"", 3669, "\"", 3677, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">This is for <i>deliveryoptiontype</i> = 2, meaning the delivery reports will be sent to the given URL as HTTP GET (query string). Please note thaat more delivery options are available.</small>
        </div>

        <div class=""form-group"">
            <label for=""txtCustomId"">Custom ID</label>
            <input type=""text"" class=""form-control"" placeholder=""Your custom ID"" name=""txtCustomId""");
                BeginWriteAttribute("value", " value=\"", 4132, "\"", 4140, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">Lets you add your own identification (tag) for the submitted message. This might help you keep track of your messages when you receive the delivery report.</small>
        </div>

        <div class=""form-group form-check"">
            <input type=""checkbox"" class=""form-check-input"" name=""cbMultiSMS"" value=""on"">
            <label class=""form-check-label"" for=""cbMultiSMS"">Enable multi SMS</label>
        </div>

        <button type=""submit"" class=""btn btn-primary"">Submit</button>
        
        <hr />
        
");
#nullable restore
#line 79 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
         if (!string.IsNullOrEmpty(Model.RawResponse))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-primary\">\r\n                <h5 class=\"alert-heading\">Raw response from server:</h5>\r\n                ");
#nullable restore
#line 83 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
           Write(Model.RawResponse);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 85 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 87 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
         if(!string.IsNullOrEmpty(Model.Message))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div style=\"margin-top: 15px;\" class=\"alert alert-secondary\">\r\n                <h5 class=\"alert-heading\">Message:</h5>\r\n                ");
#nullable restore
#line 91 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
           Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 93 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsAdvanced.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SmsTeknikXmlHttpExamples.Pages.SendSmsAdvancedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikXmlHttpExamples.Pages.SendSmsAdvancedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikXmlHttpExamples.Pages.SendSmsAdvancedModel>)PageContext?.ViewData;
        public SmsTeknikXmlHttpExamples.Pages.SendSmsAdvancedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591