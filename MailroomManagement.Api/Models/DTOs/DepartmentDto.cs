namespace MailroomManagement.Api.Models.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }
}
