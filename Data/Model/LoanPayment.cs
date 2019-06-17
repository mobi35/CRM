using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class LoanPayment
    {
        [Key]
        public int RecordId { get; set; }

        public double AmountPaid { get; set; }

        public string ModeOfPayment { get; set; }



    }
}
