using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace ActiveFinance1.Controllers
{
    public class BranchController : Controller
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IUserPower _userPower;
        private readonly IBranchRepository _branchRepository;

        public BranchController(IAccountRepository accountRepo, IUserPower userPower, IBranchRepository branchRepository)
        {
            _accountRepo = accountRepo;
            _userPower = userPower;
            _branchRepository = branchRepository;
        }
        public IActionResult ListOfBranch()
        {
            string accountId = HttpContext.Session.GetString("AccountId");
            var branch = _branchRepository.GetAll();
            UserPowerBranchViewModel accUserPowerVM = new UserPowerBranchViewModel
            {
                Branch = branch,
                UserAccountDetail = _accountRepo.FindUser(a => a.AccountId == accountId),
                UserPower = _userPower.GetIdBy(_accountRepo.FindUser(a => a.AccountId == accountId).RecordId)
            };

            return View(accUserPowerVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Branch branch)
        {

            if (ModelState.IsValid)
            {
                if (branch == null)
                {
                    return View(branch);
                }

                _branchRepository.Create(branch);

                return View("ListOfBranch", ResetBranch());
            }

            return View();
        }


        public IActionResult Delete(int id)
        {
            _branchRepository.Delete(_branchRepository.GetIdBy(id));
            return View("ListOfBranch", ResetBranch());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var branch = _branchRepository.GetIdBy(id);
            return View(branch);
        }

        [HttpPost]
        public IActionResult Update(Branch branch)
        {

            if (ModelState.IsValid)
            {
                if (branch == null)
                {
                    return View(branch);
                }

                try
                {
                    _branchRepository.Update(branch);
                }
                catch (Exception e)
                {

                }

                return View("ListOfBranch", ResetBranch());
            }

            return View();
        }
        public IEnumerable<Branch> ResetBranch()
        {
            var branch = _branchRepository.GetAll();
            return branch;
        }
    }
}
