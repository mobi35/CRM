using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class Notification
    {
        [Key]
        public int RecordId { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationTo { get; set; }
        public string IsRead { get; set; }

    }
}
