#pragma checksum "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8eaeefe6b3cdd135cc95e3a4d00de67a6a331817"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SmsTeknikWebServiceExamples.Pages.Pages_RequestDeliveryStatus), @"mvc.1.0.razor-page", @"/Pages/RequestDeliveryStatus.cshtml")]
namespace SmsTeknikWebServiceExamples.Pages
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
#line 1 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\_ViewImports.cshtml"
using SmsTeknikWebServiceExamples;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8eaeefe6b3cdd135cc95e3a4d00de67a6a331817", @"/Pages/RequestDeliveryStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11aa5d9dc438a7fb391e13f1bea0c8904200b7a6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_RequestDeliveryStatus : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
  
    ViewData["Title"] = "Request Delivery Status";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n\r\n    <h1>Request Delivery Status</h1>\r\n\r\n    <p>Enter SMS ID in text field below. We have added two SMS ID text fields to demonstrate that you can add multiple SMS ID\'s to the request.</p>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8eaeefe6b3cdd135cc95e3a4d00de67a6a3318173958", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"txtSmsid1\">Smsid # 1</label>\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"smsid\" name=\"txtSmsid1\"");
                BeginWriteAttribute("value", " value=\"", 541, "\"", 549, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n        \r\n        <div class=\"form-group\">\r\n            <label for=\"txtSmsid2\">Smsid # 2</label>\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"smsid\" name=\"txtSmsid2\"");
                BeginWriteAttribute("value", " value=\"", 757, "\"", 765, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n            \r\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        \r\n        <hr />\r\n        \r\n");
#nullable restore
#line 29 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
         if (!string.IsNullOrEmpty(Model.RawResponse))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-primary\">\r\n                <h5 class=\"alert-heading\">Raw response from server:</h5>\r\n                ");
#nullable restore
#line 33 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
           Write(Model.RawResponse);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
         if(!string.IsNullOrEmpty(Model.Message))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div style=\"margin-top: 15px;\" class=\"alert alert-secondary\">\r\n                <h5 class=\"alert-heading\">Message:</h5>\r\n                ");
#nullable restore
#line 41 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
           Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 43 "C:\Users\tomas\source\repos\SMSTeknik\SMSCodeSamples\SmsTeknikWebServiceExamples\Pages\RequestDeliveryStatus.cshtml"
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
            WriteLiteral("\r\n    \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SmsTeknikWebServiceExamples.Pages.RequestDeliveryStatusModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikWebServiceExamples.Pages.RequestDeliveryStatusModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SmsTeknikWebServiceExamples.Pages.RequestDeliveryStatusModel>)PageContext?.ViewData;
        public SmsTeknikWebServiceExamples.Pages.RequestDeliveryStatusModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
