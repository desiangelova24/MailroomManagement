using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public class User : AuditableEntity
    {
        private string _passwordHash;
        private string _email;
        private int _organizationId;

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            }
        }
        public string PasswordHash
        {
            get { return _passwordHash; }
            private set { _passwordHash = value; } // Only set internally
        }
        public int OrganizationId
        {
            get { return _organizationId; }
            set { _organizationId = value; }
        }

        public Organization Organization { get; set; }
        public int? DepartmentId { get; set; } // Nullable in case a user is not assigned to a department
        public Department Department { get; set; }
        public ICollection<Letter> Letters { get; set; } = new List<Letter>();
        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
