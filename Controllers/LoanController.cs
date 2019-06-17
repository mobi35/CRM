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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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
        private readonly IGenericLoanFieldRepository _genericRepo;
        private readonly ILoanBalanceRepository _balanceRepository;
        private readonly IUserPower _userPowerRepo;
        public LoanController(IUserPower userPowerRepo, ILoanBalanceRepository balanceRepository, IGenericLoanFieldRepository genericRepo, INotificationRepository notificationRepository, IPersonalDetailRepository personalDetailRepository, IAccountRepository accountRepository, ILoanRepository loanRepository, ITypeOfLoanRepository typeOfLoanRepository, IHostingEnvironment hosting)
        {
            _notificationRepository = notificationRepository;
            _personalDetailRepository = personalDetailRepository;
            _accountRepository = accountRepository;
            _loanRepository = loanRepository;
            _typeOfLoanRepository = typeOfLoanRepository;
            _hosting = hosting;
            _genericRepo = genericRepo;
            _userPowerRepo = userPowerRepo;
            _balanceRepository = balanceRepository;

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

                    string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + loanVM.TypeOfLoan.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueName);

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
            string accountId = HttpContext.Session.GetString("AccountId");
            List<LoanViewModel> loanVM = new List<LoanViewModel>();
            var typeOfLoans = _typeOfLoanRepository.GetAll();
            foreach (var typeOfL in typeOfLoans)
            {
                loanVM.Add(new LoanViewModel
                {
                    TypeOfLoan = typeOfL,
                    UserAccountDetail = _accountRepository.FindUser(a => a.AccountId == accountId),
                    UserPower = _userPowerRepo.GetIdBy(_accountRepository.FindUser(a => a.AccountId == accountId).RecordId)
                });
            }

            return loanVM;
        }
        public IEnumerable<AccountViewModel> AccountViewModelList()
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
                    UserPower = _userPowerRepo.GetIdBy(_accountRepository.FindUser(a => a.AccountId == c.AccountId).RecordId),
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
            var loan = _loanRepository.GetByLoanId(id);
            loan.IsApprove = "approved";
            loan.ProcessTime = DateTime.Now.AddDays(3);
            string ratub = "";
            foreach (var balance in _loanRepository.CreateBalanceList
            (loan.AmountOfLoan, loan.DesireTerm, _typeOfLoanRepository.FindLoan
            (a => a.NameOfPackageLoan == loan.TypeOfLoan).Interest, loan.RecordId))
            {
                ratub += balance.LoanId;
                _balanceRepository.Create(balance);
            }
            _loanRepository.Update(loan);

            _notificationRepository.Create(_notificationRepository.CreateNotification($"Congratulations! Your request has been approved. Please wait for 3 days for processing your loan.", loan.AccountId));
            return View("LoanApprovalTable", AccountViewModelList());
        }
        public IActionResult RejectLoan(int id)
        {
            var loan = _loanRepository.GetByLoanId(id);
            loan.IsApprove = "rejected";
            loan.IsActive = false;
            _loanRepository.Update(loan);
            var getAccount = _loanRepository.GetLoanRecord(a => a.LoanId == id);

            _notificationRepository.Create(_notificationRepository.CreateNotification($"We're sorry but your application has been rejected. PLease go to Loan history tab to modify and add more details.", loan.AccountId));

            return View("LoanApprovalTable", AccountViewModelList());
        }
        public IActionResult Application()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Application(int id)
        {
            AccountViewModel accountVM = new AccountViewModel
            {
                GenericLoanField = _genericRepo.GetByLoanId(id),
                LoanRecord = _loanRepository.GetByLoanId(id),
                LoanBalances = _balanceRepository.GetByIdList(_genericRepo.GetByLoanId(id).RecordId),
                PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == _genericRepo.GetByLoanId(id).AccountId)
            };
            return View(accountVM);
        }
        [HttpPost]
        public IActionResult Application(AccountViewModel accountVM)
        {

            return View(accountVM);
        }

        public IActionResult DueLoans()
        {
            List<LoanViewModel> loanVM = new List<LoanViewModel>();
            foreach (var loan in _balanceRepository.GetAll())
            {
                if (loan.IsPaid == false && loan.DueDate < DateTime.Now)
                {
                    loanVM.Add(
                        new LoanViewModel
                        {
                            LoanRecord = _loanRepository.GetIdBy(loan.RecordId),
                            LoanBalance = loan,
                            PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == _loanRepository.GetIdBy(loan.RecordId).AccountId)
                        }
                    );
                }


            }
            return View(loanVM);
        }

        public IActionResult PaidLoans()
        {
            List<LoanViewModel> loanVM = new List<LoanViewModel>();
            foreach (var loan in _balanceRepository.GetAll())
            {
                if (loan.IsPaid == true)
                {
                    loanVM.Add(
                      new LoanViewModel
                      {
                          LoanRecord = _loanRepository.GetIdBy(loan.RecordId),
                          LoanBalance = loan,
                          PersonalAccountDetail = _personalDetailRepository.FindPersonal(a => a.AccountId == _loanRepository.GetIdBy(loan.RecordId).AccountId)
                      }
                    );
                }


            }
            return View(loanVM);
        }

        public IActionResult PayLoan(int id)
        {
            var getLoan = _balanceRepository.GetIdBy(id);
            double totalPayment = 0;
            double temp = getLoan.Balance;
            getLoan.Balance = 0;
            totalPayment += temp;
            getLoan.IsPaid = true;
            TimeSpan timeDifferential = DateTime.Now - getLoan.DueDate;
            getLoan.Penalty = temp * 0.03;
            if (timeDifferential.Days > 7)
            {
                totalPayment += getLoan.Penalty;

            }
            getLoan.TotalPayment = totalPayment;
            _balanceRepository.Update(getLoan);
            return RedirectToAction("PaidLoans");
        }
    }
}
