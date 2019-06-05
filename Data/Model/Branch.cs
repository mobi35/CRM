using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class Branch
    {
        [Key]
        public int RecordId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }


    }
}
