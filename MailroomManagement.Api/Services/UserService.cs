using AutoMapper;
using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.User;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MailroomManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(int organizationId)
        {
            var users = await _userRepository.GetAllAsync(u => u.OrganizationId == organizationId,
                includes: query => query.Include(u => u.Organization).Include(u => u.Department));
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id,
                includes: query => query.Include(u => u.Organization).Include(u => u.Department));
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            _mapper.Map(request, user);
            await _userRepository.UpdateAsync(user,"");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;

            await _userRepository.DeleteAsync(id,"");
            return true;
        }
    }
}
