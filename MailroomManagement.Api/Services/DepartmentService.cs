using AutoMapper;
using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Departments;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MailroomManagement.Api.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync(int organizationId)
        {
            var departments = await _departmentRepository.GetAllAsync(d => d.OrganizationId == organizationId,
                includes: query => query.Include(d => d.Organization));
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id,
                includes: query => query.Include(d => d.Organization));
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentRequest request, string modifiedBy)
        {
            var department = _mapper.Map<Department>(request);
            await _departmentRepository.AddAsync(department, modifiedBy);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(int id, UpdateDepartmentRequest request, string modifiedBy)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
                return null;

            _mapper.Map(request, department);
            await _departmentRepository.UpdateAsync(department, modifiedBy);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<bool> DeleteDepartmentAsync(int id, string modifiedBy)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
                return false;

            await _departmentRepository.DeleteAsync(id, modifiedBy);
            return true;
        }
    }
}
