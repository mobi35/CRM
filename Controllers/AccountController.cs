using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.Utilities;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;
        private IPersonalDetailRepository _personalRepository;
        private readonly IUserPower _userPower;
        private IBranchRepository _branchRepository;
        public AccountController(IUserPower userPower, IBranchRepository branchRepository, IAccountRepository accountRepository, IPersonalDetailRepository personalDetailRepository)
        {
            _accountRepository = accountRepository;
            _personalRepository = personalDetailRepository;
            _userPower = userPower;
            _branchRepository = branchRepository;
        }

        [HttpPost]
        public IActionResult Login(UserAccountDetail user)
        {
            if (ModelState.IsValid)
            {
                var account = _accountRepository.FindUser
               (a => a.AccountId == user.AccountId);

                if (account == null)
                {
                    user.Message = "Your Account ID Doesn't Exist in our database.";
                    return View(user);
                }
                else
                {
                    if (account.AccountId == user.AccountId && account.Password != user.Password)
                    {
                        account.LoginAttempt++;
                        _accountRepository.Update(account);
                        return View();
                    }
                    else
                    {
                        if (account.AccountId == user.AccountId && account.Password == user.Password)
                        {
                            if (account.LoginAttempt >= 3)
                            {
                                account.Message = "Sorry but you have exceed the maximum tries. Please contact your administrator or click forgot your password to reset your account.";
                                return View(account);
                            }
                            else if (account.Role == "Customer")
                            {
                                account.LoginAttempt = 0; _accountRepository.Update(account);

                                HttpContext.Session.SetString("AccountId", account.AccountId);
                                HttpContext.Session.SetString("Role", account.Role);
                                Startup.IsSessionAvailable = true;
                                return View("Views/Customer/CustomerMain.cshtml");
                            }
                            else
                            {
                                account.LoginAttempt = 0; _accountRepository.Update(account); _accountRepository.ResetLoginAttempt(a => a.AccountId == user.AccountId);
                                HttpContext.Session.SetString("AccountId", account.AccountId);
                                HttpContext.Session.SetString("Role", account.Role);
                                Startup.IsSessionAvailable = true;
                                return View("Views/Staff/AdminDashboard.cshtml");
                            }
                        }
                    }
                }
            }
            return View();

        }


        [HttpPost]
        public IActionResult ChangePassword(UserAccountDetail userAccount)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            if (userAccount.OldPassword != _accountRepository.FindUser(a => a.AccountId == accountId).Password)
            {
                userAccount.RecordId = _accountRepository.FindUser(a => a.AccountId == accountId).RecordId;
                userAccount.Message = "Wrong Old Password";
                return View("~/Views/Customer/CustomerDetails.cshtml", userAccount);
            }
            else if (userAccount.Password != userAccount.ConfirmPassword)
            {
                userAccount.Message = "Password Doesn't Match";
                return View("~/Views/Customer/CustomerDetails.cshtml", userAccount);
            }
            var getUser = _accountRepository.GetIdBy(userAccount.RecordId);
            getUser.Password = userAccount.Password;
            _accountRepository.Update(getUser);
            userAccount.Message = "Password Changed Successfully";
            // _accountRepository.Update(userAccount);
            return View("~/Views/Customer/CustomerDetails.cshtml", userAccount);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("AccountId", "");
            Startup.IsSessionAvailable = false;
            return View("Views/Home/Index.cshtml");
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(UserAccountDetail account)
        {
            Email email = new Email();

            string randomCharEx = Guid.NewGuid().ToString("n").Substring(0, 10);
            string EmailMessage = "Please click this link to recover your account " +
                "http://localhost:49158/Account/Recover?id=" + randomCharEx +
                "  .Your Email is " + account.Email;
            email.EmailSend(EmailMessage, account.Email);
            ModelMessage mesg = new ModelMessage();
            mesg.Message = $"Hi {account.Email}! Please check your email to recover your account";
            HttpContext.Session.SetString("SecurityCode", randomCharEx);
            return View("EmailError", mesg);
        }

        [HttpPost]
        public IActionResult Recover(UserAccountDetail account)
        {
            if (ModelState.IsValid)
            {
                if (account.Password != account.ConfirmPassword)
                {
                    account.Message = "Password Doesn't Match";
                    return View(account);
                }
                var _account = _accountRepository.FindUser(a => a.AccountId == account.AccountId);
                if (_account == null)
                {
                    account.Message = "Wrong Account Id";
                    return View(account);
                }
                try
                {
                    _account.Password = account.Password;
                    _account.LoginAttempt = 0;
                    _accountRepository.Update(account);
                    account.LoginAttempt = 0; _accountRepository.Update(account);
                    //Reset Tries
                }
                catch (Exception e)
                {
                    account.Message = "Successfully Recovered Please try to login";
                    return View(account);
                }
            }
            return View();

        }

        public IActionResult Recover()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var a = _accountRepository.GetIdBy(id);

            var b = _personalRepository.FindPersonal(c => c.AccountId == a.AccountId);
            AccountUserPowerViewModel accountVM = new AccountUserPowerViewModel
            {
                UserAccountDetail = a,
                PersonalAccountDetail = b,
                UserPower = _userPower.GetIdBy(id)
            };
            return View(accountVM);
        }
        [HttpPost]
        public IActionResult Update(AccountUserPowerViewModel accountVM)
        {
            if (ModelState.IsValid)
            {
                if (accountVM.PersonalAccountDetail == null || accountVM.UserAccountDetail == null)
                {
                    accountVM.UserAccountDetail.Message = "You need to input dude";
                    return View(accountVM);
                }
                try
                {
                    // accountVM.UserAccountDetail.Message = "Successfully Registered";
                    _accountRepository.Update(accountVM.UserAccountDetail);
                    _userPower.Update(accountVM.UserPower);
                    accountVM.PersonalAccountDetail.AccountId = accountVM.UserAccountDetail.AccountId;
                    _personalRepository.Update(accountVM.PersonalAccountDetail);
                    return View("ListOfUsers", ResetList());

                }
                catch (DbUpdateConcurrencyException e)
                {

                }
            }

            // SHOW IT

            return View();
        }


        public IActionResult Create()
        {
            ViewBag.List = _branchRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountUserPowerViewModel accountVM)
        {

            ViewBag.List = _branchRepository.GetAll();
            if (ModelState.IsValid)
            {
                if (accountVM.PersonalAccountDetail == null || accountVM.UserAccountDetail == null)
                {
                    accountVM.UserAccountDetail.Message = "You need to input dude";
                    return View(accountVM);
                }

                var checkAccount = _accountRepository.FindUser(a => a.AccountId == accountVM.UserAccountDetail.AccountId);
                if (checkAccount != null)
                {

                    accountVM.UserAccountDetail.Message = "AccountID Already Existed";
                    return View(accountVM);
                }

                var checkEmail = _accountRepository.FindUser(a => a.Email == accountVM.UserAccountDetail.Email);
                if (checkAccount != null)
                {

                    accountVM.UserAccountDetail.Message = "Email Already Existed";
                    return View(accountVM);
                }

                var checkBranchManager = _accountRepository.FindUser(a => a.Role == "Branch Head" && a.Branch == accountVM.UserAccountDetail.Branch);
                if (checkBranchManager != null)
                {

                    accountVM.UserAccountDetail.Message = "There's already a Branch Manager in this branch.";
                    return View(accountVM);
                }

                accountVM.UserAccountDetail.Message = "Successfully Registered";
                _accountRepository.Create(accountVM.UserAccountDetail);
                _personalRepository.Create(accountVM.PersonalAccountDetail);
                _userPower.Create(accountVM.UserPower);
                accountVM.PersonalAccountDetail.AccountId = accountVM.UserAccountDetail.AccountId;
                _personalRepository.Update(accountVM.PersonalAccountDetail);

                return View("ListOfUsers", ResetList());
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var account1 = _accountRepository.GetIdBy(id);
            var account2 = _personalRepository.GetIdBy(id);
            _accountRepository.Delete(account1);
            _personalRepository.Delete(account2);
            return View("ListOfUsers", ResetList());
        }

        public IActionResult ListOfUsers()
        {

            return View(ResetList());
        }

        public List<AccountUserPowerViewModel> ResetList()
        {
            List<AccountUserPowerViewModel> viewM = new List<AccountUserPowerViewModel>();
            var f = _accountRepository.GetAll();
            foreach (var x in f)
            {
                viewM.Add(new AccountUserPowerViewModel
                {
                    UserAccountDetail = x,
                    UserPower = _userPower.GetIdBy(x.RecordId),
                    PersonalAccountDetail = _personalRepository.FindPersonal(a => a.AccountId == x.AccountId)
                });
            }

            return viewM;
        }

        public IActionResult EmailError()
        {
            return View();
        }

    }
}
