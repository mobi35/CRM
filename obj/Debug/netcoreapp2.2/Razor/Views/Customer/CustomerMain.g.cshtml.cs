#pragma checksum "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Customer\CustomerMain.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3da2567abf3613de0bc1792efca0aff83f58680d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerMain), @"mvc.1.0.view", @"/Views/Customer/CustomerMain.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/CustomerMain.cshtml", typeof(AspNetCore.Views_Customer_CustomerMain))]
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
#line 5 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Customer\CustomerMain.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3da2567abf3613de0bc1792efca0aff83f58680d", @"/Views/Customer/CustomerMain.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa8435ca6058be6f9410650bba89322d9376942", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerMain : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Customer\CustomerMain.cshtml"
  

    Layout = "_LayoutCustomer";

#line default
#line hidden
            BeginContext(127, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Customer\CustomerMain.cshtml"
  
    if (HttpContextAccessor.HttpContext.Session.GetString("AccountId") != null && HttpContextAccessor.HttpContext.Session.GetString("AccountId").ToString() != "")
    {
    }
    else
    {
        Context.Response.Redirect("/Home/Index");
    }

#line default
#line hidden
            BeginContext(389, 78, true);
            WriteLiteral("\r\n    <h2>\r\n        This is the customer\'s page. <br />\r\n        Account ID : ");
            EndContext();
            BeginContext(468, 73, false);
#line 20 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Customer\CustomerMain.cshtml"
                Write(HttpContextAccessor.HttpContext.Session.GetString("AccountId").ToString());

#line default
#line hidden
            EndContext();
            BeginContext(541, 18, true);
            WriteLiteral("\r\n    </h2>       ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
