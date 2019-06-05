
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class LoanBalance
    {
        public int RecordId { get; set; }
        public string LoanId { get; set; }
        public DateTime PayDate { get; set; }
        public double Payment { get; set; }
        public double Penalty { get; set; }
        public double TotalPayment { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
