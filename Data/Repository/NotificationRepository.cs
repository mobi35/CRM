using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class NotificationRepository : ActiveFinanceRepository<Notification>, INotificationRepository
    {
        private readonly AFDBContext _context;

        public NotificationRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }

        public Notification CreateNotification(string message, string accountId)
        {
            Notification notif = new Notification();
            notif.NotificationMessage = message;
            notif.NotificationTo = accountId;
            notif.NotificationDate = DateTime.Now;
            notif.IsRead = false;
            return notif;
        }

        public List<Notification> GetAllNotifByAccount(string accountId)
        {
            return _context.Notifications.Where(a => a.NotificationTo == accountId).ToList();
        }

        public List<Notification> GetListOfNotif(string accountId)
        {
            return _context.Notifications.Where(a => a.NotificationTo == accountId && a.IsRead == false).ToList();
        }
    }
}
