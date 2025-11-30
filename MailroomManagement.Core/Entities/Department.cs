using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public class Department : AuditableEntity
    {
        [Required]
        public string Name { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
