using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface ILoanRepository : IRepository<LoanRecord>
    {
        LoanRecord GetLoanRecord(Func<LoanRecord, bool> predicate);

        IEnumerable<LoanRecord> GetAllLoanRecordWith(Func<LoanRecord, bool> predicate);
    }
}
