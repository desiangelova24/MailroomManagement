using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Departments
{
    public class CreateDepartmentRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
