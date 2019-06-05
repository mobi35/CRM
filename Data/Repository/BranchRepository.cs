using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class BranchRepository : ActiveFinanceRepository<Branch> , IBranchRepository
    {
        private readonly AFDBContext context;

        public BranchRepository(AFDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
