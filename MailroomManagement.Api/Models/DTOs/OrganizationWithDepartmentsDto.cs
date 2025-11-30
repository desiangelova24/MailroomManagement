namespace MailroomManagement.Api.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for an organization with its departments.
    /// </summary>
    public class OrganizationWithDepartmentsDto : OrganizationDto
    {
        /// <summary>
        /// The list of departments in the organization.
        /// </summary>
        public List<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();
    }
}
