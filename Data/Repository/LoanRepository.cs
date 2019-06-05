using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class LoanRepository :  ActiveFinanceRepository<LoanRecord>, ILoanRepository
    {
        protected readonly AFDBContext _context;
        public LoanRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<LoanRecord> GetAllLoanRecordWith(Func<LoanRecord, bool> predicate)
        {
            return _context.LoanRecords.Where(predicate);
        }

        public LoanRecord GetLoanRecord(Func<LoanRecord, bool> predicate)
        {
            return _context.LoanRecords.FirstOrDefault(predicate);
        }

       
        
    }
}
