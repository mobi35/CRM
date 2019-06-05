using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.Utilities;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IGenericLoanFieldRepository _genericLoanField;
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonalDetailRepository _personalDetailRepository;
        private readonly ITypeOfLoanRepository _typeOfLoanRepository;
        private readonly ILoanRepository _loanRepository;

        public CustomerController(IBranchRepository branchRepository, IGenericLoanFieldRepository genericLoanField, IAccountRepository accountRepository, IPersonalDetailRepository personalDetailRepository, ITypeOfLoanRepository typeOfLoanRepository, ILoanRepository loanRepository)
        {
            _branchRepository = branchRepository;
            _genericLoanField = genericLoanField;
            _accountRepository = accountRepository;
            _personalDetailRepository = personalDetailRepository;
            _typeOfLoanRepository = typeOfLoanRepository;
            _loanRepository = loanRepository;
        }

        public IActionResult CustomerMain()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CustomerApply(int id)
        {
            AccountViewModel accountVM = new AccountViewModel
            {
                TypeOfLoan = _typeOfLoanRepository.GetIdBy(id)
            };
            return View(accountVM);
        }
        [HttpPost]
        public IActionResult CustomerApply(AccountViewModel accountVM)
        {

            if (ModelState.IsValid)
            {
                var checkEmail = _accountRepository.FindUser(a => a.Email == accountVM.UserAccountDetail.Email);
                if (checkEmail != null)
                {
                    accountVM.UserAccountDetail.Message = "This Email is already in use,";
                    return View(accountVM);
                }

                var checkSSS = _genericLoanField.FindGeneric(a => a.SSSNumber == accountVM.GenericLoanField.SSSNumber);
                if (checkSSS != null)
                {
                    accountVM.UserAccountDetail.Message = "This SSS Number is already in use,";
                    return View(accountVM);
                }

                var checkTin = _genericLoanField.FindGeneric(a => a.TinNumber == accountVM.GenericLoanField.TinNumber);
                if (checkTin != null)
                {
                    accountVM.UserAccountDetail.Message = "This Tin Number is already in use,";
                    return View(accountVM);
                }

                Email email = new Email();
                string generatedUserName = Guid.NewGuid().ToString("n").Substring(0, 6);
                string password = Guid.NewGuid().ToString("n").Substring(0, 10);
                accountVM.PersonalAccountDetail.AccountId = generatedUserName;
                accountVM.LoanRecord.AccountId = generatedUserName;
                accountVM.GenericLoanField.AccountId = generatedUserName;
                accountVM.UserAccountDetail.AccountId = generatedUserName;
                accountVM.UserAccountDetail.Password = password;

                string Message = $"Hi! {accountVM.PersonalAccountDetail.FirstName} {accountVM.PersonalAccountDetail.LastName} Thank you for applying. " +
                    $"Here's your generated Account ID and Password" +
                    $"AccountID :{generatedUserName} -  Password : {password}";
                // email.EmailSend(Message, accountVM.PersonalAccountDetail.EmailAddress);


                accountVM.UserAccountDetail.Role = "Customer";
                _genericLoanField.Create(accountVM.GenericLoanField);
                _personalDetailRepository.Create(accountVM.PersonalAccountDetail);
                _accountRepository.Create(accountVM.UserAccountDetail);
                _loanRepository.Create(accountVM.LoanRecord);
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Thank you for applying. Please wait a couple of days for reviewing of your application";
                return View("Validation", mesg);
            }

            return View(accountVM);
        }

    }
}
