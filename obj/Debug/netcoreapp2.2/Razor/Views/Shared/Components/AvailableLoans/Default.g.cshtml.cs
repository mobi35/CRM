#pragma checksum "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bc5d8c065d04ad66ed002f0b2c9bd5e83ddbf31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AvailableLoans_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AvailableLoans/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/AvailableLoans/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_AvailableLoans_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\_ViewImports.cshtml"
using ActiveFinance1;

#line default
#line hidden
#line 2 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\_ViewImports.cshtml"
using ActiveFinance1.Models;

#line default
#line hidden
#line 3 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\_ViewImports.cshtml"
using ActiveFinance1.Data.Model;

#line default
#line hidden
#line 4 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\_ViewImports.cshtml"
using ActiveFinance1.ViewModel;

#line default
#line hidden
#line 3 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bc5d8c065d04ad66ed002f0b2c9bd5e83ddbf31", @"/Views/Shared/Components/AvailableLoans/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa8435ca6058be6f9410650bba89322d9376942", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AvailableLoans_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LoanAndTypeViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerApplyOldForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerApply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
  
        int counter = 0;
        foreach(var c in Model){

#line default
#line hidden
            BeginContext(193, 90, true);
            WriteLiteral("    <div class=\"col-md-4\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            ");
            EndContext();
            BeginContext(283, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2bc5d8c065d04ad66ed002f0b2c9bd5e83ddbf316673", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 293, "~/Images/", 293, 9, true);
#line 10 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
AddHtmlAttributeValue("", 302, c.TypeOfLoan.ImagePath, 302, 23, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(358, 78, true);
            WriteLiteral("\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
            EndContext();
            BeginContext(437, 30, false);
#line 12 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                                  Write(c.TypeOfLoan.NameOfPackageLoan);

#line default
#line hidden
            EndContext();
            BeginContext(467, 44, true);
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
            EndContext();
            BeginContext(512, 24, false);
#line 13 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                                Write(c.TypeOfLoan.Description);

#line default
#line hidden
            EndContext();
            BeginContext(536, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 14 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                 
                    if(Startup.IsSessionAvailable && HttpContextAccessor.HttpContext.Session.GetString("AccountId") != null)
                        {

#line default
#line hidden
            BeginContext(714, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(715, 138, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bc5d8c065d04ad66ed002f0b2c9bd5e83ddbf319923", async() => {
                BeginContext(840, 9, true);
                WriteLiteral("Apply Now");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 17 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                                        WriteLiteral(c.TypeOfLoan.RecordId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(853, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 18 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                        }else {

#line default
#line hidden
            BeginContext(888, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(889, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bc5d8c065d04ad66ed002f0b2c9bd5e83ddbf3112930", async() => {
                BeginContext(1007, 9, true);
                WriteLiteral("Apply Now");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 19 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                                 WriteLiteral(c.TypeOfLoan.RecordId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1020, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                        }
               

#line default
#line hidden
            BeginContext(1067, 75, true);
            WriteLiteral("               \r\n        \r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 27 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
        counter++;

        if(counter % 3 == 0) {  
            

#line default
#line hidden
            BeginContext(1211, 45, false);
#line 30 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
       Write(Html.Raw("<div class='col-md-12'><hr></div>"));

#line default
#line hidden
            EndContext();
#line 30 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\AvailableLoans\Default.cshtml"
                                                          
            }
    }

#line default
#line hidden
            BeginContext(1283, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LoanAndTypeViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
