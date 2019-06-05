using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class AttachmentRepository : ActiveFinanceRepository<Attachments> , IAttachmentRepository
    {
        private readonly AFDBContext context;

        public AttachmentRepository(AFDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
