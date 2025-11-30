using System.ComponentModel.DataAnnotations;

namespace MailroomManagement.Api.Models.Requests.Organizations
{
    public class CreateOrganizationRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
}
