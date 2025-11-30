using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Core.Entities
{
    public class Letter : AuditableEntity
    {
        [Required]
        public string ReferenceNumber { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Receiver { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime DateSent { get; set; }

        public DateTime? DateReceived { get; set; }

        public string AttachmentUrl { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
