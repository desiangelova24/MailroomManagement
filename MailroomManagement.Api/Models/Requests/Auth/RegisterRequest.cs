using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Auth
{
    public class RegisterRequest
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        [Required]
        public string Username { get; set; }


        /// <summary>
        /// The email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        /// <summary>
        /// The password of the user.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// The ID of the organization the user belongs to.
        /// </summary>
        [Required]
        public int OrganizationId { get; set; }

        /// <summary>
        /// The ID of the department the user belongs to.
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }
    }
}
