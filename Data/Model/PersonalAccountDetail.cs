using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model
{
    public class PersonalAccountDetail
    {
        [Key]
        public int RecordId { get; set; }
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string MaritalStatus { get; set; }
        public string MothersMaiden { get; set; }
        public string HomeAddress { get; set; }
        public string Zipcode { get; set; }
        public string YearsOfStay { get; set; }
        public string HomeOwnership { get; set; }
        public string TelNo { get; set; }
        public string MobileNo { get; set; }
        public string ProvincialAddress { get; set; }
        public string EmailAddress { get; set; }


    }
}
