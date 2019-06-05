using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Controllers
{
    public class StaffController : Controller
    {
        private IAccountRepository _accountDetailsRepository;
        private IPersonalDetailRepository _personalDetailRepository;
        public StaffController(IAccountRepository accountDetailsRepository, IPersonalDetailRepository personalDetailRepository)
        {
            _accountDetailsRepository = accountDetailsRepository;
            _personalDetailRepository = personalDetailRepository;
        } 

           public IActionResult AdminDashboard(){
            
            return View();
        }


        public IActionResult ListOfLoans(){
            
            return View();
        }
    }
}
