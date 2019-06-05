using ActiveFinance1.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data
{
    public class AFDBContext : DbContext
    {

        public AFDBContext(DbContextOptions<AFDBContext> options) : base(options)
        {

        }
        public DbSet<UserAccountDetail> UserAccountDetails { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<PersonalAccountDetail> PersonalAccountDetails { get; set; }
        public DbSet<GenericLoanField> GenericLoanFields { get; set; }
        public DbSet<TypeOfLoan> TypeOfLoans { get; set; }
        public DbSet<LoanRecord> LoanRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
