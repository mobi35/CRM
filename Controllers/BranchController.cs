using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public IActionResult ListOfBranch()
        {
            var branch = _branchRepository.GetAll();
            return View(branch);
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

                try { 
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
