using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class UserAccountDetail
    {
        [Key]
        public int RecordId { get; set; }
     
        public string AccountId { get; set; }
    
        public string Password { get; set; }
        public string Role { get; set; }
        public int LoginAttempt { get; set; }
        public DateTime DateJoined { get; set; }
        public int AccountAvailability { get; set; }
        public string Power { get; set; }
        public string Notification { get; set; }
        public string Branch { get; set; }
        public string Mandatory { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public virtual PersonalAccountDetail PersonalAccountDetail { get; set; }
        public int PersonalAccountDetailId { get; set; }


    }
}
