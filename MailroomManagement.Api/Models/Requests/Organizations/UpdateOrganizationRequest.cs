using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Organizations
{
    public class UpdateOrganizationRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
