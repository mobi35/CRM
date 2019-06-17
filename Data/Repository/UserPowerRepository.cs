using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class UserPowerRepository : ActiveFinanceRepository<UserPower>, IUserPower
    {
        protected readonly AFDBContext _context;

        public UserPowerRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
