using ActiveFinance1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.ViewModel
{
    public class LoanViewModel
    {
        public LoanBalance LoanBalance { get; set; }

        public LoanRecord LoanRecord { get; set; }

        public TypeOfLoan TypeOfLoan { get; set; }
        public UserAccountDetail UserAccountDetail { get; set; }

        public UserPower UserPower { get; set; }

        public PersonalAccountDetail PersonalAccountDetail { get; set; }
    }
}
