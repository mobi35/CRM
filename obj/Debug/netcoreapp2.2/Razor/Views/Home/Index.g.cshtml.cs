#pragma checksum "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58d0292124bb5a8a8d8aa3b62e253a269eca2a17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58d0292124bb5a8a8d8aa3b62e253a269eca2a17", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa8435ca6058be6f9410650bba89322d9376942", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
       Layout = "_Layout";

#line default
#line hidden
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(78, 35, false);
#line 7 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("Carousel"));

#line default
#line hidden
            EndContext();
            BeginContext(113, 160, true);
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Services</h1>\r\n            <p><a href=\"https://docs.microsoft.com/aspnet/core\"> </a></p>\r\n             ");
            EndContext();
            BeginContext(274, 45, false);
#line 12 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Home\Index.cshtml"
        Write(await Component.InvokeAsync("LoanCalculator"));

#line default
#line hidden
            EndContext();
            BeginContext(319, 77, true);
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n        <hr />\r\n\r\n        <div class=\"row\">\r\n\r\n        ");
            EndContext();
            BeginContext(397, 45, false);
#line 20 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Home\Index.cshtml"
   Write(await Component.InvokeAsync("AvailableLoans"));

#line default
#line hidden
            EndContext();
            BeginContext(442, 22, true);
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591