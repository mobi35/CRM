using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class LoanBalanceRepository : ActiveFinanceRepository<LoanBalance>, ILoanBalanceRepository
    {
        private readonly AFDBContext _context;

        public LoanBalanceRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateBalance(List<LoanBalance> list)
        {
            foreach (var cr in list)
            {
                _context.LoanBalances.Add(cr);
                await _context.SaveChangesAsync();
            }
        }


        public List<LoanBalance> GetByIdList(int id)
        {
            return _context.LoanBalances.Where(a => a.RecordId == id).ToList();
        }
    }
}
