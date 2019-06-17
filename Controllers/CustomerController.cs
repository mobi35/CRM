using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.Utilities;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IHostingEnvironment _hosting;
        private readonly IAttachmentRepository _attachmentsRepo;
        private readonly IUserPower _userPower;
        private readonly ILoanBalanceRepository _loanBalance;
        private readonly INotificationRepository _notifRepo;
        public CustomerController(IUserPower userPower, ILoanBalanceRepository loanBalance, INotificationRepository notifRepo, IAttachmentRepository attachmentsRepo, IHostingEnvironment hosting, IBranchRepository branchRepository, IGenericLoanFieldRepository genericLoanField, IAccountRepository accountRepository, IPersonalDetailRepository personalDetailRepository, ITypeOfLoanRepository typeOfLoanRepository, ILoanRepository loanRepository)
        {
            _branchRepository = branchRepository;
            _genericLoanField = genericLoanField;
            _accountRepository = accountRepository;
            _personalDetailRepository = personalDetailRepository;
            _typeOfLoanRepository = typeOfLoanRepository;
            _loanRepository = loanRepository;
            _hosting = hosting;
            _attachmentsRepo = attachmentsRepo;
            _userPower = userPower;
            _loanBalance = loanBalance;
            _notifRepo = notifRepo;
        }
        public IActionResult ResubmitApplication()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ModifyApplication(int id)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            if (_loanRepository.HasActiveLoan(accountId) == false)
            {
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Sorry but you already have an active application.";
                return View("Validation", mesg);
            }
            AccountViewModel accountVM = new AccountViewModel
            {
                TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == _loanRepository.GetByLoanId(id).TypeOfLoan),
                LoanRecord = _loanRepository.GetByLoanId(id),
                GenericLoanField = _genericLoanField.FindGeneric(a => a.AccountId == accountId),
                PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == accountId)
            };
            return View(accountVM);
        }
        public IActionResult ModifyApplication(AccountViewModel accountVM)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            if (ModelState.IsValid)
            {
                Email email = new Email();
                accountVM.PersonalAccountDetail.AccountId = accountId;
                accountVM.LoanRecord.AccountId = accountId;
                accountVM.GenericLoanField.AccountId = accountId;
                int loanId = accountVM.LoanRecord.LoanId;
                accountVM.LoanRecord.LoanId = loanId;
                accountVM.GenericLoanField.LoanId = loanId;
                int recordId = _loanRepository.CreateID();
                recordId++;
                string uniqueName = null;
                if (accountVM.GenericLoanField.Attachments != null)
                {
                    foreach (IFormFile photo in accountVM.GenericLoanField.Attachments)
                    {
                        string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        _attachmentsRepo.AddAttachments(photo.FileName, accountId, recordId, uniqueName);
                    }
                }
                string Message = $"Hi! {accountVM.PersonalAccountDetail.FirstName} {accountVM.PersonalAccountDetail.LastName} Thank you for applying. ";
                // email.EmailSend(Message, accountVM.PersonalAccountDetail.EmailAddress);
                try
                {
                    _genericLoanField.Update(accountVM.GenericLoanField);
                    _personalDetailRepository.Update(accountVM.PersonalAccountDetail);
                    _loanRepository.Update(accountVM.LoanRecord);
                }
                catch (Exception e)
                {

                }
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Thank you for applying. Please wait a couple of days for reviewing of your application" + Message;
                _notifRepo.Create(_notifRepo.CreateNotification($"Hi {accountId}! Thank you for applying. Please wait 3 days for verification..", accountId));
                return View("Validation", mesg);
            }
            return View(accountVM);

        }
        public IActionResult ReadAlready(int id)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            var listOfNotifs = _notifRepo.GetListOfNotif(accountId);

            var notif = _notifRepo.GetIdBy(id);
            notif.IsRead = true;
            _notifRepo.Update(notif);
            var listOfAllNotifs = _notifRepo.GetAllNotifByAccount(accountId);
            List<ModelMessage> modelMessage = new List<ModelMessage>();
            foreach (var notifs in listOfAllNotifs)
            {
                modelMessage.Add(
                         new ModelMessage { Notification = notifs }
                         );
            }
            return View("CustomerNotification", modelMessage);
        }
        public IActionResult CustomerNotification()
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            var listOfNotifs = _notifRepo.GetAllNotifByAccount(accountId);
            List<ModelMessage> modelMessage = new List<ModelMessage>();
            foreach (var notif in listOfNotifs)
            {
                modelMessage.Add(
                         new ModelMessage { Notification = notif }
                         );
            }
            return View(modelMessage);
        }
        public IActionResult CustomerApplicationOld()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomerApplyOldForm(int id)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            if (_loanRepository.HasActiveLoan(accountId) == false)
            {
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Sorry but you already have an active application.";
                return View("Validation", mesg);
            }
            AccountViewModel accountVM = new AccountViewModel
            {
                TypeOfLoan = _typeOfLoanRepository.GetIdBy(id),
                GenericLoanField = _genericLoanField.FindGeneric(a => a.AccountId == accountId),
                PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == accountId)
            };
            return View(accountVM);
        }
        [HttpPost]
        public IActionResult CustomerApplyOldForm(AccountViewModel accountVM)
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            if (ModelState.IsValid)
            {
                Email email = new Email();
                accountVM.PersonalAccountDetail.AccountId = accountId;
                accountVM.LoanRecord.AccountId = accountId;
                accountVM.GenericLoanField.AccountId = accountId;
                int loanId = _loanRepository.CreateLoanID();
                loanId++;
                accountVM.LoanRecord.LoanId = loanId;
                accountVM.GenericLoanField.LoanId = loanId;
                int recordId = _loanRepository.CreateID();
                recordId++;
                string uniqueName = null;
                if (accountVM.GenericLoanField.Attachments != null)
                {
                    foreach (IFormFile photo in accountVM.GenericLoanField.Attachments)
                    {
                        string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        _attachmentsRepo.AddAttachments(photo.FileName, accountId, recordId, uniqueName);
                    }
                }
                string Message = $"Hi! {accountVM.PersonalAccountDetail.FirstName} {accountVM.PersonalAccountDetail.LastName} Thank you for applying. ";
                // email.EmailSend(Message, accountVM.PersonalAccountDetail.EmailAddress);
                _genericLoanField.Create(accountVM.GenericLoanField);
                _personalDetailRepository.Create(accountVM.PersonalAccountDetail);
                _loanRepository.Create(accountVM.LoanRecord);
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Thank you for applying. Please wait a couple of days for reviewing of your application" + Message;
                _notifRepo.Create(_notifRepo.CreateNotification($"Hi {accountId}! Thank you for applying. Please wait 3 days for verification..", accountId));
                return View("Validation", mesg);
            }
            return View(accountVM);
        }
        public IActionResult CustomerMain()
        {
            return View();
        }
        public IActionResult CustomerLoanHistory()
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            List<LoanViewModel> loanVM = new List<LoanViewModel>();
            foreach (var loans in _loanRepository.GetAllLoanRecordWith(a => a.AccountId == accountId))
            {
                loanVM.Add(new LoanViewModel
                {
                    LoanRecord = loans,
                    TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == _loanRepository.GetLoanRecord(c => c.AccountId == accountId).TypeOfLoan)
                });
            }
            return View(loanVM);
        }

        public IActionResult CustomerDetails()
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            var getId = -1;
            foreach (var c in _accountRepository.GetAll())
            {
                if (c.AccountId == accountId)
                {
                    getId = c.RecordId;
                    // var userAccount = _accountRepository.FindWithPersonal(a => a.RecordId == getId);
                    return View(c);
                }

            }
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
        [HttpGet]
        public IActionResult CustomerApplicationView(int id)
        {
            AccountViewModel accountVM = new AccountViewModel
            {
                GenericLoanField = _genericLoanField.GetByLoanId(id),
                LoanRecord = _loanRepository.GetByLoanId(id),
                LoanBalances = _loanBalance.GetByIdList(_genericLoanField.GetByLoanId(id).RecordId),
                PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == _genericLoanField.GetByLoanId(id).AccountId)
            };
            return View(accountVM);
        }
        [HttpPost]
        public IActionResult CustomerApplicationView(AccountViewModel accountVM)
        {
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


                accountVM.LoanRecord.IsActive = true;
                int loanId = _loanRepository.CreateLoanID();
                loanId++;
                accountVM.LoanRecord.LoanId = loanId;
                accountVM.GenericLoanField.LoanId = loanId;
                int recordId = _loanRepository.CreateID();
                recordId++;
                string uniqueName = null;
                if (accountVM.GenericLoanField.Attachments != null)
                {
                    foreach (IFormFile photo in accountVM.GenericLoanField.Attachments)
                    {
                        string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        _attachmentsRepo.AddAttachments(photo.FileName, generatedUserName, recordId, uniqueName);
                    }
                }
                string Message = $"Hi! {accountVM.PersonalAccountDetail.FirstName} {accountVM.PersonalAccountDetail.LastName} Thank you for applying. " +
                    $"Here's your generated Account ID and Password" +
                    $"AccountID :{generatedUserName} -  Password : {password}";
                // email.EmailSend(Message, accountVM.PersonalAccountDetail.EmailAddress);
                accountVM.UserAccountDetail.Role = "Customer";
                _genericLoanField.Create(accountVM.GenericLoanField);
                _personalDetailRepository.Create(accountVM.PersonalAccountDetail);
                _accountRepository.Create(accountVM.UserAccountDetail);
                _loanRepository.Create(accountVM.LoanRecord);
                _userPower.Create(new Data.Model.UserPower { UserLevel = 3 });
                ModelMessage mesg = new ModelMessage();
                mesg.Message = "Thank you for applying. Please wait a couple of days for reviewing of your application" + Message;
                _notifRepo.Create(_notifRepo.CreateNotification($"Hi {generatedUserName}! Thank you for applying. Please wait 3 days for verification..", generatedUserName));

                return View("Validation", mesg);
            }

            return View(accountVM);
        }

    }
}
