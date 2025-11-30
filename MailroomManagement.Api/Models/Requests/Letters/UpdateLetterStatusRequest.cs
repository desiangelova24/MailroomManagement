using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Letters
{
    public class UpdateLetterStatusRequest
    {
        [Required]
        public string Status { get; set; }
    }
}
