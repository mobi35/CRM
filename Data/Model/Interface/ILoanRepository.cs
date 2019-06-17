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

        int CreateLoanID();
        int CreateID();
        List<LoanBalance> CreateBalanceList(double principalLoan, int months, double interest, int recordId);

        LoanRecord GetByLoanId(int id);
        LoanRecord GetByRecordId(int id);

        bool HasActiveLoan(string accountId);

    }
}
