namespace MailroomManagement.Api.Models.Requests.Auth
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
