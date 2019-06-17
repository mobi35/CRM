using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class UserPower
    {
        [Key]
        public int RecordId { get; set; }
        /*
        admin/branch head - level 1
        branch manager - level 2
        customer - level 3 */
        public int UserLevel { get; set; }

        public bool User_CanAddLoan { get; set; }
        public bool User_CanAddFeedback { get; set; }
        public bool CanViewUser { get; set; }
        public bool CanAddUser { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanEditUser { get; set; }


        public bool CanViewTypeOfLoan { get; set; }
        public bool CanAddTypeOfLoan { get; set; }
        public bool CanDeleteTypeOfLoan { get; set; }
        public bool CanEditTypeOfLoan { get; set; }



        public bool CanViewBranch { get; set; }
        public bool CanAddBranch { get; set; }
        public bool CanDeleteBranch { get; set; }
        public bool CanEditBranch { get; set; }


        public bool CanViewLoanRequest { get; set; }
        public bool CanApproveLoanRequest { get; set; }
        public bool CanRejectLoanRequest { get; set; }

        public bool CanViewApprovedTable { get; set; }

        public bool CanViewRejectedLoanTable { get; set; }
        public bool CanViewLoanApplication { get; set; }
    }

}