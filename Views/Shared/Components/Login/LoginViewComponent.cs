using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Views.Shared.Components.Login
{
  

    public class LoginViewComponent : ViewComponent
    {

        public LoginViewComponent()
        {
        
        }
        public IViewComponentResult Invoke()
        {
            var user = new UserAccountDetail();

            return View("Default", user);
        }
    }
}
