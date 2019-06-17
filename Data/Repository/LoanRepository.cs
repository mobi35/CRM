using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class LoanRepository : ActiveFinanceRepository<LoanRecord>, ILoanRepository
    {
        protected readonly AFDBContext _context;
        private readonly ILoanBalanceRepository _loanBalance;

        public LoanRepository(AFDBContext context, ILoanBalanceRepository loanBalance) : base(context)
        {
            _context = context;
            _loanBalance = loanBalance;
        }

        public int CreateLoanID()
        {
            if (_context.LoanRecords.LastOrDefault() == null)
                return 1000000;
            else
                return _context.LoanRecords.LastOrDefault().LoanId;
        }

        public int CreateID()
        {
            if (_context.LoanRecords.LastOrDefault() == null)
                return 0;
            else
                return _context.LoanRecords.LastOrDefault().RecordId;
        }

        public IEnumerable<LoanRecord> GetAllLoanRecordWith(Func<LoanRecord, bool> predicate)
        {
            return _context.LoanRecords.Where(predicate);
        }

        public LoanRecord GetByLoanId(int id)
        {
            return _context.LoanRecords.Include(a => a.LoanBalances).FirstOrDefault(a => a.LoanId == id);
        }
        public LoanRecord GetByRecordId(int id)
        {
            return _context.LoanRecords
            .Include(a => a.LoanBalances)
            .FirstOrDefault(a => a.RecordId == id);
        }

        public LoanRecord GetLoanRecord(Func<LoanRecord, bool> predicate)
        {
            return _context.LoanRecords.Include(a => a.LoanBalances).FirstOrDefault(predicate);
        }


        public double LoanFormula(double principalLoan, int months, double interest)
        {
            // MONTHLY PAYMENTS
            return (principalLoan * Math.Pow((interest / 1) + 1, (months)) * interest / 1) / (Math.Pow(interest / 1 + 1, (months)) - 1);
        }
        public List<LoanBalance> CreateBalanceList(double principalLoan, int months, double interest, int recordId)
        {
            var startingDate = DateTime.Now.AddDays(3);
            List<LoanBalance> loanBalanceList = new List<LoanBalance>();
            for (int i = 1; i <= months; i++)
            {
                LoanBalance loanBalance = new LoanBalance();
                loanBalance.Balance = LoanFormula(principalLoan, months, interest) / months;
                loanBalance.DueDate = startingDate.AddMonths(i);
                loanBalance.RecordId = recordId;
                loanBalance.IsPaid = false;
                loanBalance.TotalPayment = 0;
                loanBalance.Payment = 0;
                loanBalance.Penalty = 0;
                loanBalanceList.Add(loanBalance);
            }

            return loanBalanceList;
        }

        public bool HasActiveLoan(string accountId)
        {
            foreach (var loanRec in GetAllLoanRecordWith(a => a.AccountId == accountId))
            {
                if (loanRec.IsActive == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;

        }
    }
}
