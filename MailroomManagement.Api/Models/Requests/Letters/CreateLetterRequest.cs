using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Letters
{
    public class CreateLetterRequest
    {
        [Required]
        public string ReferenceNumber { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Receiver { get; set; }

        public IFormFile Attachment { get; set; }
    }
}
