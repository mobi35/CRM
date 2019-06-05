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
    public class ListOfBranchViewComponent : ViewComponent
    {
        private readonly IBranchRepository _typeOfBranch;
        public ListOfBranchViewComponent(IBranchRepository typeOfBranch)
        {
                _typeOfBranch = typeOfBranch;   
        }
        public IViewComponentResult Invoke( ){
           var all = _typeOfBranch.GetAll();
           List<BranchViewModel> branchViewModel = new List<BranchViewModel>();
           foreach(var c in all){
            branchViewModel.Add(new BranchViewModel{
                Branch = c
            });
           }
            return View("Default", branchViewModel);
        }   
    }
}
