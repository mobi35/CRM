using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace ActiveFinance1.ViewModel
{
    public class AccountViewModel
    {

        public UserAccountDetail UserAccountDetail { get; set; }

        public PersonalAccountDetail PersonalAccountDetail { get; set; }

        public GenericLoanField GenericLoanField { get; set; }

        public LoanRecord LoanRecord { get; set; }
        public IEnumerable<LoanBalance> LoanBalances { get; set; }

        public TypeOfLoan TypeOfLoan { get; set; }
        public UserPower UserPower { get; set; }
    }
}
