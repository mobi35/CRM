using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveFinance1.Data.Model.Interface
{
    public interface IAttachmentRepository : IRepository<Attachments>
    {
        void AddAttachments(string attachmentName, string customerName, int recordId, string uniqueName);
    }
}
