#pragma checksum "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bf7e3c786a14d15f6144bdca4aaa45823c1f344"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SmsTeknikXmlHttpExamples.Pages.Pages_SendSmsFromString), @"mvc.1.0.razor-page", @"/Pages/SendSmsFromString.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bf7e3c786a14d15f6144bdca4aaa45823c1f344", @"/Pages/SendSmsFromString.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ae29bda048aa02b4f117ac6ffd7666114417271", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SendSmsFromString : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
  
    ViewData["Title"] = "Send Message";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div>
    <h1>Send SMS simple - with XML generated as string</h1>
    <p>Use this method to send a SMS. The request in configured in an object that is serialized and posted to endpoint. The result is traversed and determined if success.</p>

    <p>See code behind for more properties.</p>

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bf7e3c786a14d15f6144bdca4aaa45823c1f3443992", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"txtSender\">Sender</label>\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"Sender, eg. Test or phone number\" name=\"txtSender\"");
                BeginWriteAttribute("value", " value=\"", 648, "\"", 656, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">Alphanumeric name or phone number (remember country prefix, eg. +4790000000.</small>
        </div>
        
        <div class=""form-group"">
            <label for=""txtRecipient1"">Recipient</label>
            <input type=""text"" class=""form-control"" placeholder=""Phone number"" name=""txtRecipient1""");
                BeginWriteAttribute("value", " value=\"", 1013, "\"", 1021, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">Phone number starting with country prefix, eg. +4790000000</small>
        </div>

        <div class=""form-group"">
            <label for=""txtRecipient2"">Additional recipient</label>
            <input type=""text"" class=""form-control"" placeholder=""Phone number"" name=""txtRecipient2""");
                BeginWriteAttribute("value", " value=\"", 1363, "\"", 1371, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
            <small class=""form-text text-muted"">This is only to demonstrate that you can add multiple recipients in the same request.</small>
        </div>

        <div class=""form-group"">
            <label for=""txtText"">Text</label>
            <textarea class=""form-control"" name=""txtText"" rows=""3""></textarea>
            <small class=""form-text text-muted"">Remember to activate <i>multisms</i> and <i>maxmultisms</i> if more that 160 chars.</small>
        </div>

        <button type=""submit"" class=""btn btn-primary"">Submit</button>
        
        <hr />
        
");
#nullable restore
#line 45 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
         if (!string.IsNullOrEmpty(Model.RawResponse))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-primary\">\r\n                <h5 class=\"alert-heading\">Raw response from server:</h5>\r\n                ");
#nullable restore
#line 49 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
           Write(Model.RawResponse);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 51 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 53 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
         if(!string.IsNullOrEmpty(Model.Message))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div style=\"margin-top: 15px;\" class=\"alert alert-secondary\">\r\n                <h5 class=\"alert-heading\">Message:</h5>\r\n                ");
#nullable restore
#line 57 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
           Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 59 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikXmlHttpExamples\Pages\SendSmsFromString.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SmsTeknikXmlHttpExamples.Pages.SendSmsFromStringModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikXmlHttpExamples.Pages.SendSmsFromStringModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikXmlHttpExamples.Pages.SendSmsFromStringModel>)PageContext?.ViewData;
        public SmsTeknikXmlHttpExamples.Pages.SendSmsFromStringModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
