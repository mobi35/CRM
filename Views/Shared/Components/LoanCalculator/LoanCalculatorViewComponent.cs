using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ActiveFinance1.Views.Shared.Components.Loans
{
    public class LoanCalculatorViewComponent : ViewComponent
    {
        private readonly ITypeOfLoanRepository _typeOfLoan;
        public LoanCalculatorViewComponent(ITypeOfLoanRepository typeOfLoan)
        {
            _typeOfLoan = typeOfLoan;
        }
        public IViewComponentResult Invoke()
        {
            var all = _typeOfLoan.GetAll();
            List<LoanViewModel> loanViewModel = new List<LoanViewModel>();
            foreach (var c in all)
            {
                loanViewModel.Add(new LoanViewModel
                {
                    TypeOfLoan = c
                });
            }
            return View("Default", loanViewModel);
        }
    }
}
