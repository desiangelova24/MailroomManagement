using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Departments;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync(int organizationId);
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentRequest request, string modifiedBy);
        Task<DepartmentDto> UpdateDepartmentAsync(int id, UpdateDepartmentRequest request, string modifiedBy);
        Task<bool> DeleteDepartmentAsync(int id, string modifiedBy);
    }
}
