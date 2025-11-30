using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public interface IAuditableEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}
