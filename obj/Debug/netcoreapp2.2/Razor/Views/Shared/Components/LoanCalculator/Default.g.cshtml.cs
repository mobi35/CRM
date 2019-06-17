#pragma checksum "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "686d5ce17e4682c5f838f6a5fa081e0ac54feb0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LoanCalculator_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LoanCalculator/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/LoanCalculator/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_LoanCalculator_Default))]
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
#line 2 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#line 3 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"686d5ce17e4682c5f838f6a5fa081e0ac54feb0d", @"/Views/Shared/Components/LoanCalculator/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa8435ca6058be6f9410650bba89322d9376942", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LoanCalculator_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LoanViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(95, 4023, true);
            WriteLiteral(@"
<button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModalCenter"">
Calculate Loan
</button>

<!-- Modal -->
<div class=""modal fade"" id=""exampleModalCenter"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
  <div class=""modal-dialog modal-dialog-centered"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"" id=""exampleModalLongTitle"">Loan Calculator</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
  
      <div class=""modal-body"">
       
       <script>

function ComputeLoan() {

 $('#loan-table').html("""");
 var amount = $('#desiredAmount').val();
 var months = $('#desiredTerm').val();


 var maxLoan = parseInt($('#max-loan').val());
 var minLoan = parseInt($('#min-loan').val());
 var max = '₱ ' + maxLoan.toFixed(2).replace(/(");
            WriteLiteral(@"\d)(?=(\d\d\d)+(?!\d))/g, ""$1,"");
 var min = '₱ ' + minLoan.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ""$1,"");
 if ($('select').val() == """") {
  $('#type-validation').html(""Please select the type of loan"");
  return false;
 } else {
  $('#type-validation').html("""");
 }


 if (parseInt($('#min-loan').val()) - 1 >= parseInt($('#desiredAmount').val()) ||  parseInt($('#max-loan').val()) - 1 <= parseInt($('#desiredAmount').val()) ) {
  $('#amount-validation').html(""Minimum of "" + min + "" and Maximum of "" + max);
  return false;
 } else if ($('#desiredAmount').val() == """") {
  $('#amount-validation').html(""Please write your desired amount"");
  return false;
 } else {
  $('#amount-validation').html("""");
 }

 if (parseInt($('#desiredTerm').val()) >= 100 || parseInt($('#desiredTerm').val()) <= 0) {
  $('#month-validation').html(""Invalid Month ( 1 - 100 only)"");
  return false;
 }
 if ($('#desiredTerm').val() == """") {
  $('#month-validation').html(""Please write your desired term"");
  retur");
            WriteLiteral(@"n false;
 } else {
  $('#month-validation').html("""");
 }


 var interest_rate = $('#interest').val();
 var interest = interest_rate * .01;
 var payment = ((amount / months) + interest).toFixed(2);
 var totalMonthly = (amount * Math.pow((interest / 1) + 1, (months)) *
  interest / 1) / (Math.pow(interest / 1 + 1, (months)) - 1);

 var f = new Array();
 for (i = 0; i < months; i++) {
  f[i] = new Array();
  for (j = 0; j <= 1; j++) {
   if (j == 0) {
    f[i][j] = totalMonthly;
    continue;
   }

   if (j == 1) {
    f[i][j] = interest;
    continue;
   }
  }
 }

 var table = document.createElement('TABLE');
 table.className = ""table table-hover table-sm"";
 let newRow = table.insertRow(0);

 var cell1 = newRow.insertCell(0);
 var cell2 = newRow.insertCell(1);
 var cell3 = newRow.insertCell(2);
 newRow.className = ""table-active"";
 cell1.className = ""thead-light""
 cell1.innerHTML = ""<b>Month</b>"";
 cell2.innerHTML = ""<b>Interest</b>"";
 cell3.innerHTML = ""<b>Amount</b>"";
 v");
            WriteLiteral(@"ar count = 1;
 for (s = 0; s < months; s++) {
  let newRow = table.insertRow(-1);
  var cell1 = newRow.insertCell(0);
  var cell2 = newRow.insertCell(1);
  var cell3 = newRow.insertCell(2);

  cell1.innerHTML = count;
  var num = '₱ ' + totalMonthly.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ""$1,"");
  cell2.innerHTML = interest * 100 + ""%"";
  cell3.innerHTML = num;
  count++;
 }

 let lastRow = table.insertRow(-1);
 var lastCell1 = lastRow.insertCell(0);
 var lastCell2 = lastRow.insertCell(1);
 var lastCell3 = lastRow.insertCell(2);

 lastCell1.innerHTML = """";
 lastRow.className = ""table-success"";
 var totalAmount = totalMonthly * months;
 var num = '₱ ' + totalAmount.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ""$1,"");
 lastCell2.innerHTML = ""Total Growth"";
 lastCell3.innerHTML = num;

 $('#loan-table').append(table);

}

</script>

  <select required class=""form-control"" id=""type-of-loan""> 
      ");
            EndContext();
            BeginContext(4118, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "686d5ce17e4682c5f838f6a5fa081e0ac54feb0d8903", async() => {
                BeginContext(4135, 19, true);
                WriteLiteral("Select Type Of Loan");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 134 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
      
        foreach (var c in Model)
        {

#line default
#line hidden
            BeginContext(4218, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(4230, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "686d5ce17e4682c5f838f6a5fa081e0ac54feb0d10642", async() => {
                BeginContext(4279, 30, false);
#line 137 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
                                                       Write(c.TypeOfLoan.NameOfPackageLoan);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 137 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
               WriteLiteral(c.TypeOfLoan.NameOfPackageLoan);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4318, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 138 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
        }
    

#line default
#line hidden
            BeginContext(4338, 1233, true);
            WriteLiteral(@"    
  </select>
   <div class=""alert-danger""> <i id=""type-validation"" ></i></div>  
    <input  id=""interest"" type=""hidden"" />
    <input id=""stack"" type=""hidden"" />
    <input id=""min-loan"" type=""hidden"" />
    <input id=""max-loan"" type=""hidden"" />

<div><br>    <b>Interest</b> : <i id=""interest-value""></i> % <br>
  
      <b>Minimum Amount</b> : <i id=""min-loan-value""></i> <br>
       <b>Maximum Amount</b> : <i id=""max-loan-value""></i> <br>
       <br>
</div>

    <input required placeholder=""Desired Amount"" id=""desiredAmount"" class=""form-control"" type=""number"" />
  <div class=""alert-danger""> <i id=""amount-validation"" ></i></div>  
     <input min = ""20"" max = ""20"" required placeholder=""Desired Period"" id=""desiredTerm""  class=""form-control"" type=""number"" />
  <div class=""alert-danger""> <i id=""month-validation"" ></i></div> 
  <hr>
  
  <div id=""loan-table"">

  </div>


      </div>
      <div class=""modal-footer"">

       <button  onclick=""ComputeLoan()""  class=""btn btn-success""");
            WriteLiteral(" ><span class=\"fa fa-calculator\"> </span> Calculate</button>\r\n             <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n      </div>\r\n \r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n");
            EndContext();
#line 177 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
  
    var dataJson = new HtmlString(JsonConvert.SerializeObject(Model));

#line default
#line hidden
            BeginContext(5650, 42, true);
            WriteLiteral("\r\n<script>  \r\n\r\n\r\n\r\nvar obj = JSON.parse(\'");
            EndContext();
            BeginContext(5693, 8, false);
#line 185 "c:\Users\Adrian Radores\Desktop\ActiveFinanceFiles\ActiveFinanceFiles\ActiveFinance1\Views\Shared\Components\LoanCalculator\Default.cshtml"
                 Write(dataJson);

#line default
#line hidden
            EndContext();
            BeginContext(5701, 754, true);
            WriteLiteral(@"');

$(document).ready(function() { 
$('#type-of-loan').change(function(){ 
 for (var i in obj) {
     console.log(obj[i]);
     if(obj[i].TypeOfLoan.NameOfPackageLoan == $('#type-of-loan').val() ){
       
        $('#interest').val(obj[i].TypeOfLoan.Interest);
        $('#stack').val(obj[i].TypeOfLoan.Stack);
        $('#min-loan').val(obj[i].TypeOfLoan.MinimumLoan);
        $('#max-loan').val(obj[i].TypeOfLoan.MaximumLoan);

       $('#interest-value').text(obj[i].TypeOfLoan.Interest);
        $('#stack-value').text(obj[i].TypeOfLoan.Stack);
        $('#min-loan-value').text(obj[i].TypeOfLoan.MinimumLoan);
        $('#max-loan-value').text(obj[i].TypeOfLoan.MaximumLoan);
        break;
     }
    }

});
});
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LoanViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
