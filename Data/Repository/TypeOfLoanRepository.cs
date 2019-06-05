using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class TypeOfLoanRepository : ActiveFinanceRepository<TypeOfLoan> , ITypeOfLoanRepository
    {
        private readonly AFDBContext context;

        public TypeOfLoanRepository(AFDBContext context) : base(context)
        {
            this.context = context;
        }

        public TypeOfLoan FindLoan(Func<TypeOfLoan, bool> predicate)
        {
            return context.TypeOfLoans.FirstOrDefault(predicate);
        }
    }
}
