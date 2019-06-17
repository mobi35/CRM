using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class Attachments
    {
        [Key]
        public int pKeyOfAttachments { get; set; }
        public int RecordId { get; set; }
        public string AccountId { get; set; }
        public string UniqueName { get; set; }
        public bool IsVerified { get; set; }
        public string File { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
