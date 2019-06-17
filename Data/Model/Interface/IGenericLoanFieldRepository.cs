using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface IGenericLoanFieldRepository : IRepository<GenericLoanField>
    {
        GenericLoanField FindGeneric(Func<GenericLoanField, bool> predicate);
        GenericLoanField GetByLoanId(int id);
    }
}
