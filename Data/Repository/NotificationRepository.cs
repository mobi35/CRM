using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class NotificationRepository :  ActiveFinanceRepository<Notification>, INotificationRepository
    {
        private readonly AFDBContext _context;

        public NotificationRepository(AFDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
