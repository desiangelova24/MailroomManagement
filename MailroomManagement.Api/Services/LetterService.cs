
using AutoMapper;
using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Letters;
using MailroomManagement.Api.Models.Responses.Letters;
using MailroomManagement.Api.Services.CloudServices;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MailroomManagement.Api.Services
{
    public class LetterService : ILetterService
    {
        private readonly IRepository<Letter> _letterRepository;
        private readonly IUserRepository _userRepository;
        private readonly IS3Service _s3Service;
        private readonly ISQSService _sqsService;
        private readonly IMapper _mapper;

        public LetterService(
            IRepository<Letter> letterRepository,
            IUserRepository userRepository,
            IS3Service s3Service,
            ISQSService sqsService, IMapper mapper)
        {
            _letterRepository = letterRepository;
            _userRepository = userRepository;
            _s3Service = s3Service;
            _sqsService = sqsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LetterDto>> GetLettersByUserId(int userId)
        {
            var letters = await _letterRepository.GetAllAsync(l => l.UserId == userId,
                includes: query => query.Include(l => l.User).ThenInclude(u => u.Organization));
            return _mapper.Map<IEnumerable<LetterDto>>(letters);
        }

        public async Task<LetterDto> GetLetterById(int id)
        {
            var letter = await _letterRepository.GetByIdAsync(id,
                includes: query => query.Include(l => l.User).ThenInclude(u => u.Organization));
            return _mapper.Map<LetterDto>(letter);
        }

        public async Task<LetterDto> SendLetter(CreateLetterRequest request, int userId, string sendBy)
        {
            var letter = _mapper.Map<Letter>(request);
            letter.UserId = userId;
            letter.DateSent = DateTime.Now;
            letter.Status = "Sent";

            await _letterRepository.AddAsync(letter, sendBy);

            if (request.Attachment != null)
            {
                using var memoryStream = new MemoryStream();
                await request.Attachment.CopyToAsync(memoryStream);
                var fileKey = $"letters/{letter.Id}/{request.Attachment.FileName}";
                await _s3Service.UploadFileAsync(memoryStream, fileKey, request.Attachment.ContentType);
                letter.AttachmentUrl = fileKey;
                await _letterRepository.UpdateAsync(letter, sendBy);
            }

            var message = JsonSerializer.Serialize(new { LetterId = letter.Id, Status = letter.Status });
            await _sqsService.SendMessageAsync("letter-queue", message);

            return _mapper.Map<LetterDto>(letter);
        }

        public async Task<bool> UpdateLetterStatus(int id, string status, string modifiedBy)
        {
            var letter = await _letterRepository.GetByIdAsync(id);
            if (letter == null)
                return false;

            letter.Status = status;
            if (status == "Received")
                letter.DateReceived = DateTime.Now;

            await _letterRepository.UpdateAsync(letter, modifiedBy);
            return true;
        }
    }
}
