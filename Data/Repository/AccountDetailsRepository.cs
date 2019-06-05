using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class AccountDetailsRepository : ActiveFinanceRepository<UserAccountDetail>, IAccountRepository
    {
        protected readonly AFDBContext _context;

        public AccountDetailsRepository(AFDBContext context) : base (context)
        {
            _context = context;
        }

        public UserAccountDetail FindUser(Func<UserAccountDetail, bool> predicate)
        {
            return _context.UserAccountDetails
              .Where(predicate).FirstOrDefault();
        }

     

        public IEnumerable<UserAccountDetail> FindWithPersonal(Func<UserAccountDetail, bool> predicate)
        {
            return _context.UserAccountDetails
                .Include(a => a.PersonalAccountDetail)
                .Where(predicate);
        }

    
        public void ResetLoginAttempt(Func<UserAccountDetail, bool> predicate)
        {
           var account = _context.UserAccountDetails
                .Where(predicate).FirstOrDefault();
            account.LoginAttempt = 0;
            _context.Update(account);
        }
    }
}
