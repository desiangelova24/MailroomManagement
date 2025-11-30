namespace MailroomManagement.Api.Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
