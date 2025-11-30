using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.User;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(int organizationId);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserRequest request);
        Task<bool> DeleteUserAsync(int id);
    }
}
