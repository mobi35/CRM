using ActiveFinance1.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AFDBContext>();


                var burnik = new UserAccountDetail { AccountId = "Admin1", Password = "Admin1", Branch = "Baguio", Email = "Maeee", LoginAttempt = 0, Role = "Admin" };

                var pers2 = new PersonalAccountDetail { AccountId = "Admin1", FirstName = "Adrian", LastName = "Espiel", MiddleName = "Radores" };

                var powers = new UserPower { UserLevel = 1 };
                context.UserPowers.Add(powers);
                context.PersonalAccountDetails.Add(pers2);
                context.UserAccountDetails.Add(burnik);



                var f2 = new Attachments
                {
                    RecordId = 1,
                    AccountId = "Admin1",
                    File = "SSS FoXXrm",
                };
                var f4 = new Attachments
                {
                    RecordId = 1,
                    AccountId = "Admin1",
                    File = "BCCATEE",
                };

                var f3 = new Attachments
                {
                    RecordId = 1,
                    AccountId = "Admin1",
                    File = "SSS Form",
                };

                var f5 = new Attachments
                {
                    RecordId = 2,
                    AccountId = "Admin1",
                    File = "SXSS Form",
                };
                var f6 = new Attachments
                {
                    RecordId = 3,
                    AccountId = "Admin1",
                    File = "RDC Form",
                };
                var f7 = new Attachments
                {
                    RecordId = 3,
                    AccountId = "Admin1",
                    File = "BC Form",
                };
                context.Attachments.Add(f3);
                context.Attachments.Add(f2);
                context.Attachments.Add(f2);
                context.Attachments.Add(f5);
                context.Attachments.Add(f6);
                context.Attachments.Add(f7);
                var g1 = new GenericLoanField
                {
                    AccountId = "Admin1",
                    LoanId = 1000001,
                };


                context.GenericLoanFields.Add(g1);

                var loan1 = new LoanRecord
                {
                    AmountOfLoan = 2000,
                    Branch = "Baguio",
                    AccountId = "Admin1",
                    DesireTerm = 20,
                    LoanAmountAmortization = "23",
                    LoanId = 1000001,
                    LoanMonth = 20,
                    PurposeOfLoan = "No Cash",
                    RemainingMonth = 17,
                    TypeOfLoan = "SME Loan"
                };


                context.LoanRecords.Add(loan1);

                var branch1 = new Branch
                {
                    BranchName = "Baguio",
                    BranchAddress = "Burnham Park CA"
                };

                var branch2 = new Branch
                {
                    BranchName = "Paranaque",
                    BranchAddress = "Paranaque Park CA"
                };

                var branch3 = new Branch
                {
                    BranchName = "Forbes Park",
                    BranchAddress = "Forbes Park Park CA"
                };

                var branch4 = new Branch
                {
                    BranchName = "Mandaluyong",
                    BranchAddress = "Mandaluyong Park CA"
                };


                context.Branches.Add(branch1);
                context.Branches.Add(branch2);
                context.Branches.Add(branch3);
                context.Branches.Add(branch4);


                var typeOfLoan1 = new TypeOfLoan
                {
                    NameOfPackageLoan = "Agricultural Equipment Financial",
                    Interest = 10,
                    Description = "Plants and trees",
                    MinimumLoan = 20000,
                    MaximumLoan = 100000
                };

                var typeOfLoan2 = new TypeOfLoan
                {
                    NameOfPackageLoan = "SME Loan",
                    Interest = 5,
                    Description = "Money Money",
                    MinimumLoan = 80000,
                    MaximumLoan = 200000
                };

                var typeOfLoan3 = new TypeOfLoan
                {
                    NameOfPackageLoan = "Travel Assistance Loan",
                    Interest = 2,
                    Description = "Airplanes",
                    MinimumLoan = 80000,
                    MaximumLoan = 500000
                };

                var typeOfLoan4 = new TypeOfLoan
                {
                    NameOfPackageLoan = "Vehicle Financing",
                    Interest = 2,
                    Description = "Car Money",
                    MinimumLoan = 50000,
                    MaximumLoan = 500000
                };

                context.TypeOfLoans.Add(typeOfLoan1);
                context.TypeOfLoans.Add(typeOfLoan2);
                context.TypeOfLoans.Add(typeOfLoan3);
                context.TypeOfLoans.Add(typeOfLoan4);
                context.SaveChanges();
            }
        }
    }
}
