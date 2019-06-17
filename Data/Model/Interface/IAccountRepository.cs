using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface IAccountRepository : IRepository<UserAccountDetail>
    {
        UserAccountDetail FindUser(Func<UserAccountDetail, bool> predicate);
        IEnumerable<UserAccountDetail> FindWithPersonal(Func<UserAccountDetail, bool> predicate);
        void ResetLoginAttempt(Func<UserAccountDetail, bool> predicate);

        IEnumerable<UserAccountDetail> GetAllWithPersonal();
    }
}
