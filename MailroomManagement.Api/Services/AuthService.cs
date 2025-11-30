using MailroomManagement.Api.Models.Requests.Auth;
using MailroomManagement.Api.Models.Responses.Auth;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MailroomManagement.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthResult> Register(RegisterRequest request)
        {
            var userExists = await _userRepository.GetUserByEmailAsync(request.Email);
            if (userExists != null)
                return new AuthResult { Success = false, Message = "Email already in use." };

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                OrganizationId = request.OrganizationId,
                DepartmentId = request.DepartmentId
            };
            user.SetPassword(request.Password);

            await _userRepository.AddAsync(user, "System");

            return new AuthResult { Success = true, Message = "User created successfully." };
        }

        public async Task<AuthResult> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return new AuthResult { Success = false, Message = "User not found." };

            if (!user.VerifyPassword(request.Password))
                return new AuthResult { Success = false, Message = "Invalid password." };

            var token = GenerateJwtToken(user);

            return new AuthResult { Success = true, Token = token, Message = "Login successful." };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}

