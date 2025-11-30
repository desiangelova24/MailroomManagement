using AutoMapper;
using MailroomManagement.Api.Models.Requests;
using MailroomManagement.Api.Models.Requests.Setup;
using MailroomManagement.Api.Models.Responses;
using MailroomManagement.Api.Models.Responses.Setup;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailroomManagement.Api.Services
    {
        public class SetupService : ISetupService
        {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SetupService(
            IRepository<Organization> organizationRepository,
            IRepository<Department> departmentRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<InitializeResponse> InitializeAsync(InitializeRequest request)
        {
            const string createdBy = "System";

            // Create an organization
            var organization = new Organization
            {
                Name = request.OrganizationName,
                Address = request.OrganizationAddress
            };
            await _organizationRepository.AddAsync(organization, createdBy);

            // Create departments
            var departments = new List<Department>();
            foreach (var deptRequest in request.Departments)
            {
                var department = _mapper.Map<Department>(deptRequest);
                department.OrganizationId = organization.Id;
                await _departmentRepository.AddAsync(department, createdBy);
                departments.Add(department);
            }

            // Create users
            var users = new List<User>();
            foreach (var userRequest in request.Users)
            {
                var user = _mapper.Map<User>(userRequest);
                user.OrganizationId = organization.Id;
                user.DepartmentId = departments[userRequest.DepartmentIndex].Id;
                user.SetPassword(userRequest.Password);
                await _userRepository.AddAsync(user, createdBy);
                users.Add(user);
            }

            // Prepare response
            var response = new InitializeResponse
            {
                Success = true,
                Message = "Initial setup completed successfully.",
                OrganizationId = organization.Id,
                Departments = departments.Select(d => new DepartmentResponse { Id = d.Id, Name = d.Name }).ToList(),
                Users = users.Select(u => new UserResponse { Id = u.Id, Username = u.Username, Email = u.Email }).ToList()
            };

            return response;
        }
    }
    }


