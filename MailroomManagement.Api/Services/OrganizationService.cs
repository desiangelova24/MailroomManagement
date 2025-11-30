using AutoMapper;
using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Organizations;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Repositories;

namespace MailroomManagement.Api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public OrganizationService(IRepository<Organization> organizationRepository, IRepository<Department> departmentRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
        }
        public async Task<IEnumerable<OrganizationWithDepartmentsDto>> GetAllOrganizationsWithDepartmentsAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            var result = new List<OrganizationWithDepartmentsDto>();

            foreach (var organization in organizations)
            {
                var departments = await _departmentRepository.GetAllAsync(d => d.OrganizationId == organization.Id);
                var organizationDto = _mapper.Map<OrganizationWithDepartmentsDto>(organization);
                organizationDto.Departments = _mapper.Map<List<DepartmentDto>>(departments);
                result.Add(organizationDto);
            }

            return result;
        }
        public async Task<OrganizationDto> GetOrganizationByIdAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            return _mapper.Map<OrganizationDto>(organization);
        }

        public async Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationRequest request, string createdBy)
        {
            var organization = _mapper.Map<Organization>(request);
            await _organizationRepository.AddAsync(organization, createdBy);
            return _mapper.Map<OrganizationDto>(organization);
        }

        public async Task<OrganizationDto> UpdateOrganizationAsync(int id, UpdateOrganizationRequest request, string modifiedBy)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            if (organization == null)
                return null;

            _mapper.Map(request, organization);
            await _organizationRepository.UpdateAsync(organization, modifiedBy);
            return _mapper.Map<OrganizationDto>(organization);
        }

        public async Task<bool> DeleteOrganizationAsync(int id, string modifiedBy)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            if (organization == null)
                return false;

            await _organizationRepository.DeleteAsync(id, modifiedBy);
            return true;
        }
    }
}
