using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public class Organization : AuditableEntity
    {
        [Required]
        public required string Name { get; set; }
        public required string Address { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
