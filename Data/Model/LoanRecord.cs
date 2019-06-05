using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class LoanRecord
    {
        [Key]
        public int RecordId { get; set; }
        public string LoanId { get; set; }
        public string AccountId { get; set; }
        public string TypeOfLoan { get; set; }
        public double AmountOfLoan { get; set; }
        public string LoanAmountAmortization { get; set; }
        public int LoanMonth { get; set; }
        public int RemainingMonth { get; set; }
        public int DesireTerm { get; set; }
        public string PurposeOfLoan { get; set; }
        public string Branch { get; set; }
        public string IsApprove { get; set; }
    }
}
