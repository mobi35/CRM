
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class LoanBalance
    {
        [Key]
        public int LoanBalKey { get; set; }
        public int RecordId { get; set; }
        public int LoanId { get; set; }
        public DateTime PayDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
        public double Balance { get; set; }
        public double Payment { get; set; }
        public double Penalty { get; set; }
        public double TotalPayment { get; set; }
        [NotMapped]
        public string Message { get; set; }
    }
}
