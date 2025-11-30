namespace MailroomManagement.Api.Models.DTOs
{
    public class OrganizationDto
    {
        /// <summary>
        /// The ID of the organization.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the organization.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The address of the organization.
        /// </summary>
        public string Address { get; set; }
    }
}
