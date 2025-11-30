using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Letters;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface ILetterService
    {
        Task<IEnumerable<LetterDto>> GetLettersByUserId(int userId);
        Task<LetterDto> SendLetter(CreateLetterRequest request, int userId, string sendBy);
        Task<LetterDto> GetLetterById(int id);
        Task<bool> UpdateLetterStatus(int id, string status, string modifiedBy);
    }
}
