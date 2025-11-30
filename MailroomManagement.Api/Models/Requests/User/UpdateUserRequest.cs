using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.User
{
    public class UpdateUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? DepartmentId { get; set; }
    }
}
