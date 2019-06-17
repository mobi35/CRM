using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Notification CreateNotification(string message, string accountId);

        List<Notification> GetAllNotifByAccount(string accountId);
        List<Notification> GetListOfNotif(string accountId);
    }
}
