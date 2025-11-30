namespace MailroomManagement.Api.Models.Requests.Setup
{
    public class InitializeRequest
    {
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public List<DepartmentRequest> Departments { get; set; } = new List<DepartmentRequest>();
        public List<UserRequest> Users { get; set; } = new List<UserRequest>();
    }

    public class DepartmentRequest
    {
        public string Name { get; set; }
    }

    public class UserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentIndex { get; set; }
    }
}
