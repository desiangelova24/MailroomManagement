using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
