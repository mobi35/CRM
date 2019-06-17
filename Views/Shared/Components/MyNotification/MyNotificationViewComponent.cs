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


    public class MyNotificationViewComponent : ViewComponent
    {
        private readonly INotificationRepository _notification;

        public MyNotificationViewComponent(INotificationRepository Notification)
        {
            _notification = Notification;
        }
        public IViewComponentResult Invoke(string id)
        {
            List<ModelMessage> modelMessage = new List<ModelMessage>();
            var listNotif = _notification.GetListOfNotif(id);
            foreach (var s in listNotif)
            {
                modelMessage.Add(new ModelMessage
                {
                    Notification = s
                });
            }
            return View("Default", modelMessage);
        }
    }
}
