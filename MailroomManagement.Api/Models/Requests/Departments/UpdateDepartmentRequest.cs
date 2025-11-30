using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Departments
{
    public class UpdateDepartmentRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
