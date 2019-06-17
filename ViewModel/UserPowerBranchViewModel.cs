using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data.Model;

namespace ActiveFinance1.ViewModel
{
    public class UserPowerBranchViewModel
    {
        public IEnumerable<Branch> Branch { get; set; }
        public UserPower UserPower { get; set; }
        public UserAccountDetail UserAccountDetail { get; set; }
    }
}
