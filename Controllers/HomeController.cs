using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActiveFinance1.Models;
using ActiveFinance1.Data;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.ViewModel;
using ActiveFinance1.Data.Model;

namespace ActiveFinance1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITypeOfLoanRepository _typeOfLoanRepository;

        public HomeController(ITypeOfLoanRepository typeOfLoanRepository)
        {
            _typeOfLoanRepository = typeOfLoanRepository;
        }

        public IActionResult Index()
        {
          
                return View(ResetLoan());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IEnumerable<TypeOfLoan> ResetLoan()
        {
            var typeOfLoan = _typeOfLoanRepository.GetAll();
            return typeOfLoan;
        }
    }
}
