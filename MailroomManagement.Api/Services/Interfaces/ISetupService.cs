using MailroomManagement.Api.Models.Requests.Setup;
using MailroomManagement.Api.Models.Responses.Setup;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface ISetupService
    {
        Task<InitializeResponse> InitializeAsync(InitializeRequest request);
    }
}
