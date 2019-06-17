using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace ActiveFinance1.ViewModel
{
    public class AccountUserPowerViewModel
    {

        public UserAccountDetail UserAccountDetail { get; set; }

        public UserPower UserPower { get; set; }
        public PersonalAccountDetail PersonalAccountDetail { get; set; }

    }
}
