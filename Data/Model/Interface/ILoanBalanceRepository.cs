using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface ILoanBalanceRepository : IRepository<LoanBalance>
    {
        List<LoanBalance> GetByIdList(int id);

        void CreateBalance(List<LoanBalance> list);
    }
}
