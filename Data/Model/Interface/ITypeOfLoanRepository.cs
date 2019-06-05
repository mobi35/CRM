using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface ITypeOfLoanRepository : IRepository<TypeOfLoan>
    {
        TypeOfLoan FindLoan(Func<TypeOfLoan, bool> predicate);
    }
}
