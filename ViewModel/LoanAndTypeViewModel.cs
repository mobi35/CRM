using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace ActiveFinance1.ViewModel
{
    public class LoanAndTypeViewModel
    {
      
        public LoanRecord LoanRecord { get; set; }

        public TypeOfLoan TypeOfLoan { get; set; }
    }
}
