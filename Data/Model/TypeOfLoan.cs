using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class TypeOfLoan
    {
        [Key]
        public int RecordId { get; set; }
        public double Interest { get; set; }
        public double MinimumLoan { get; set; }
        public double MaximumLoan { get; set; }
        public string NameOfPackageLoan { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string CustomField4 { get; set; }
        public string CustomField5 { get; set; }
        public string ImagePath { get; set; }
        public int Stack { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Description { get; set; }


        [NotMapped]
        public string Message { get; set; }


    }
}
