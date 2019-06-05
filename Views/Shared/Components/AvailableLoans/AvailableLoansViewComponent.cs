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
    public class AvailableLoansViewComponent : ViewComponent
    {
        private readonly ITypeOfLoanRepository _typeOfLoan;
        public AvailableLoansViewComponent(ITypeOfLoanRepository typeOfLoan)
        {
                _typeOfLoan = typeOfLoan;   
        }
        public IViewComponentResult Invoke( ){
           var all = _typeOfLoan.GetAll();

            List<LoanAndTypeViewModel> loanAndTypeVM = new List<LoanAndTypeViewModel>();
            foreach (var c in all)
            {
                loanAndTypeVM.Add(new LoanAndTypeViewModel
                {
                    TypeOfLoan = c
                });
            }

            return View("Default", loanAndTypeVM);
        }   
    }
}
