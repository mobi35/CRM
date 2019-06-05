using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Controllers
{
    public class LoanController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IPersonalDetailRepository _personalDetailRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ITypeOfLoanRepository _typeOfLoanRepository;
        private readonly IHostingEnvironment _hosting;

        public LoanController(INotificationRepository notificationRepository, IPersonalDetailRepository personalDetailRepository, IAccountRepository accountRepository, ILoanRepository loanRepository, ITypeOfLoanRepository typeOfLoanRepository, IHostingEnvironment hosting)
        {
           _notificationRepository = notificationRepository;
            _personalDetailRepository = personalDetailRepository;
            _accountRepository = accountRepository;
            _loanRepository = loanRepository;
            _typeOfLoanRepository = typeOfLoanRepository;
            _hosting = hosting;
        }

        public IActionResult ListOfLoans()
        {
            List<LoanViewModel> loanVM = new List<LoanViewModel>();

          var loans = _loanRepository.GetAll();
            foreach (var loan in loans)
            {
                loanVM.Add(new LoanViewModel
                {
                    LoanRecord = loan
                });
            }
            
            return View(loanVM);
        }

        public IActionResult ListOfTypeOfLoans()
        {
        
            return View(ResetList());
        }


        public IActionResult CreateTypeOfLoan()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult CreateTypeOfLoan(LoanViewModel loanVM)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (loanVM.TypeOfLoan.Image != null)
                {
                  
                  string uploadsFolder =  Path.Combine(_hosting.WebRootPath, "Images");
                   uniqueName = Guid.NewGuid().ToString() + "_" + loanVM.TypeOfLoan.Image.FileName;
                  string filePath =  Path.Combine(uploadsFolder, uniqueName);

                    loanVM.TypeOfLoan.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var checkLoanName = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == loanVM.TypeOfLoan.NameOfPackageLoan);
                if (checkLoanName != null)
                {

                    loanVM.TypeOfLoan.Message = "AccountID Already Existed";
                    return View(loanVM);

                }
                loanVM.TypeOfLoan.Message = "Successfully Registered";
                    loanVM.TypeOfLoan.ImagePath = uniqueName;
                _typeOfLoanRepository.Create(loanVM.TypeOfLoan);

                return View("ListOfTypeOfLoans", ResetList());
            }

            return View();
        }


        [HttpGet]
        public IActionResult UpdateTypeOfLoan(int id)
        {
            var model = new LoanViewModel
            {
                TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.RecordId == id)
            };
            return View(model);
        }

        public IActionResult DeleteTypeOfLoan(int id)
        {
            _typeOfLoanRepository.Delete(_typeOfLoanRepository.GetIdBy(id));
            return View("ListOfTypeOfLoans", ResetList());
        }
        [HttpPost]
        public IActionResult UpdateTypeOfLoan(LoanViewModel loanVM)
        {
            if (ModelState.IsValid)
            {
              
                if (loanVM.TypeOfLoan.Image != null)
                {
                    string uniqueName = null;
                    string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + loanVM.TypeOfLoan.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueName);

                    loanVM.TypeOfLoan.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    loanVM.TypeOfLoan.ImagePath = uniqueName;
                }
                _typeOfLoanRepository.Update(loanVM.TypeOfLoan);

                return View("ListOfTypeOfLoans", ResetList());
            }

            return View();
        }

   

        public IEnumerable<LoanViewModel> ResetList()
        {
            List<LoanViewModel> loanVM = new List<LoanViewModel>();
            var typeOfLoans = _typeOfLoanRepository.GetAll();
            foreach (var typeOfL in typeOfLoans)
            {
                loanVM.Add(new LoanViewModel
                {
                    TypeOfLoan = typeOfL
                });
            }

            return loanVM;
        }

        public IEnumerable <AccountViewModel> AccountViewModelList()
        {
            List<AccountViewModel> list = new List<AccountViewModel>();
            var loans = _loanRepository.GetAllLoanRecordWith(a => a.IsApprove == null);
            foreach (var c in loans)
            {
                list.Add(new AccountViewModel
                {
                    LoanRecord = c,
                    UserAccountDetail = _accountRepository.FindUser(a => a.AccountId == c.AccountId),
                    TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == c.TypeOfLoan),
                    PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == c.AccountId)
                });
            }
            return list;
        }

        public IActionResult LoanApprovalTable()
        {
            
            return View(AccountViewModelList());
        }

        public IActionResult RejectedLoanTable()
        {
            List<AccountViewModel> list = new List<AccountViewModel>();
            var loans = _loanRepository.GetAllLoanRecordWith(a => a.IsApprove == "rejected");
            foreach (var c in loans)
            {
                list.Add(new AccountViewModel
                {
                    LoanRecord = c,
                    UserAccountDetail = _accountRepository.FindUser(a => a.AccountId == c.AccountId),
                    TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == c.TypeOfLoan),
                    PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == c.AccountId)
                });
            }
            return View(list);
        }

        public IActionResult ApprovedLoanTable()
        {
            List<AccountViewModel> list = new List<AccountViewModel>();
            var loans = _loanRepository.GetAllLoanRecordWith(a => a.IsApprove == "approved");
            foreach (var c in loans)
            {
                list.Add(new AccountViewModel
                {
                    LoanRecord = c,
                    UserAccountDetail = _accountRepository.FindUser(a => a.AccountId == c.AccountId),
                    TypeOfLoan = _typeOfLoanRepository.FindLoan(a => a.NameOfPackageLoan == c.TypeOfLoan),
                    PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == c.AccountId)
                });
            }
            return View(list);
        }

        public IActionResult ApproveLoan(int id)
        {
            var loan = _loanRepository.GetIdBy(id);
            loan.IsApprove = "approved";
            _loanRepository.Update(loan);
            var getAccount = _loanRepository.GetLoanRecord(a => a.RecordId == id);
            var notif = new Notification();
            notif.NotificationDate = DateTime.Now;
            notif.NotificationTo = getAccount.AccountId;
            notif.NotificationMessage = "Congratulations! Your Loan has been approved! Please wait for 3 days ";
            _notificationRepository.Create(notif);
            return View("LoanApprovalTable", AccountViewModelList());
        }


        public IActionResult RejectLoan(int id)
        {
            var loan = _loanRepository.GetIdBy(id);
            loan.IsApprove = "rejected";
            _loanRepository.Update(loan);
            var getAccount = _loanRepository.GetLoanRecord(a => a.RecordId == id);
            var notif = new Notification();
            notif.NotificationDate = DateTime.Now;
            notif.NotificationTo = getAccount.AccountId;
            notif.NotificationMessage = "I'm sorry but your application is rejected.";
            _notificationRepository.Create(notif);
            return View("LoanApprovalTable", AccountViewModelList());
        }
    }
}
