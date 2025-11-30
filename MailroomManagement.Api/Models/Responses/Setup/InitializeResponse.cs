namespace MailroomManagement.Api.Models.Responses.Setup
{
    public class InitializeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int OrganizationId { get; set; }
        public List<DepartmentResponse> Departments { get; set; } = new List<DepartmentResponse>();
        public List<UserResponse> Users { get; set; } = new List<UserResponse>();
    }

    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
