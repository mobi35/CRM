using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Repository
{
    public class AttachmentRepository : ActiveFinanceRepository<Attachments>, IAttachmentRepository
    {
        private readonly AFDBContext context;

        public AttachmentRepository(AFDBContext context) : base(context)
        {
            this.context = context;
        }

        public async void AddAttachments(string attachmentName, string customerName, int recordId, string uniqueName)
        {
            Attachments attachment = new Attachments();
            attachment.RecordId = recordId;
            attachment.UniqueName = uniqueName;
            attachment.AccountId = customerName;
            attachment.File = attachmentName;
            attachment.DateAdded = DateTime.Now;
            context.Add(attachment);
            await context.SaveChangesAsync();
        }
    }
}
