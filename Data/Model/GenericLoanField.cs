using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class GenericLoanField
    {
        [Key]
        public int RecordId { get; set; }
        public int LoanId { get; set; }
        public string AccountId { get; set; }
        public string ReferredBy { get; set; }
        public string TinNumber { get; set; }
        public string SSSNumber { get; set; }
        public string EmployementStatus { get; set; }
        public string NameOfCompany { get; set; }
        public string YearsOfCompany { get; set; }
        public string CompanyAddress { get; set; }
        public string Position { get; set; }
        public double AnnualIncome { get; set; }

        public string FinBusiness { get; set; }
        public string FinSpouse { get; set; }
        public string FinOthers { get; set; }
        public string LessFood { get; set; }
        public string LessRent { get; set; }
        public string LessUtilities { get; set; }
        public string LessEduc { get; set; }
        public string LessOthers { get; set; }
        public string FinNet { get; set; }
        public string Creditor { get; set; }
        public string CreditCard { get; set; }
        public string CreditNumber { get; set; }
        public string CreditLimit { get; set; }
        public DateTime CreditExpiration { get; set; }
        public string Bank { get; set; }
        public string CurrentChecking { get; set; }
        public string Savings { get; set; }
        [NotMapped]
        public List<IFormFile> Attachments { get; set; }
        public virtual List<Attachments> ListOfAttachments { get; set; }

        public string AnswerField1 { get; set; }
        public string AnswerField2 { get; set; }
        public string AnswerField3 { get; set; }
        public string AnswerField4 { get; set; }
        public string AnswerField5 { get; set; }


    }
}
