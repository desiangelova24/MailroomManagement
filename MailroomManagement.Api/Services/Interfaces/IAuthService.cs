using MailroomManagement.Api.Models.Requests.Auth;
using MailroomManagement.Api.Models.Responses.Auth;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Register(RegisterRequest request);
        Task<AuthResult> Login(LoginRequest request);
    }
}
