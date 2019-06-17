using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class GenericLoanFieldRepository : ActiveFinanceRepository<GenericLoanField>, IGenericLoanFieldRepository
    {
        private readonly AFDBContext context;
        public GenericLoanFieldRepository(AFDBContext context) : base(context)
        {
            this.context = context;
        }
        public GenericLoanField GetByLoanId(int id)
        {
            return _context.GenericLoanFields
            .Include(a => a.ListOfAttachments)
            .FirstOrDefault(a => a.LoanId == id);
        }
        public GenericLoanField FindGeneric(Func<GenericLoanField, bool> predicate)
        {
            return _context.GenericLoanFields.Where(predicate).FirstOrDefault();
        }
    }
}
