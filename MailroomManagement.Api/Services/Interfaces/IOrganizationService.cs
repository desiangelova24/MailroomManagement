using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Organizations;

namespace MailroomManagement.Api.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync();
        Task<IEnumerable<OrganizationWithDepartmentsDto>> GetAllOrganizationsWithDepartmentsAsync();
        Task<OrganizationDto> GetOrganizationByIdAsync(int id);
        Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationRequest request, string createdBy);
        Task<OrganizationDto> UpdateOrganizationAsync(int id, UpdateOrganizationRequest request, string modifiedBy);
        Task<bool> DeleteOrganizationAsync(int id, string modifiedBy);
    }
}
