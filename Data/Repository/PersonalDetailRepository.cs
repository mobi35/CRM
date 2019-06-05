using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class PersonalDetailRepository : ActiveFinanceRepository<PersonalAccountDetail>, IPersonalDetailRepository  
    {
        private readonly AFDBContext _context;

        public PersonalDetailRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }

        public PersonalAccountDetail FindPersonal(Func<PersonalAccountDetail, bool> predicate)
        {
            return _context.PersonalAccountDetails
                  .FirstOrDefault(predicate);
        }
    }
}
