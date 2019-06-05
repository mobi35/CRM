using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface IPersonalDetailRepository : IRepository<PersonalAccountDetail>
    {
        PersonalAccountDetail FindPersonal(Func<PersonalAccountDetail, bool> predicate);
    }
}
