using MailroomManagement.Api.Models.Requests.Organizations;
using MailroomManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailroomManagement.Api.Controllers
{
    /// <summary>
    /// Controller for managing organizations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : BaseController
    {
        private readonly IOrganizationService _organizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsController"/> class.
        /// </summary>
        /// <param name="organizationService">The organization service.</param>
        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// Retrieves all organizations.
        /// </summary>
        /// <returns>A list of organizations.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOrganizations()
        {
            var organizations = await _organizationService.GetAllOrganizationsAsync();
            return Ok(organizations);
        }

        /// <summary>
        /// Retrieves all organizations with their departments.
        /// </summary>
        /// <returns>A list of organizations with their departments.</returns>
        [HttpGet("with-departments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOrganizationsWithDepartments()
        {
            var organizations = await _organizationService.GetAllOrganizationsWithDepartmentsAsync();
            return Ok(organizations);
        }

        /// <summary>
        /// Retrieves an organization by its ID.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>The organization with the specified ID.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            var organization = await _organizationService.GetOrganizationByIdAsync(id);
            if (organization == null)
                return NotFound();
            return Ok(organization);
        }

        /// <summary>
        /// Creates a new organization.
        /// </summary>
        /// <param name="request">The request containing the organization details.</param>
        /// <returns>The created organization.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationRequest request)
        {
            var organization = await _organizationService.CreateOrganizationAsync(request, "");
            return CreatedAtAction(nameof(GetOrganizationById), new { id = organization.Id }, organization);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateOrganization(int id, [FromBody] UpdateOrganizationRequest request)
        {
            var organization = await _organizationService.UpdateOrganizationAsync(id, request, CurrentUserName);
            if (organization == null)
                return NotFound();
            return Ok(organization);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrganization(int id)
        //{
        //    var result = await _organizationService.DeleteOrganizationAsync(id, CurrentUserName);
        //    if (!result)
        //        return NotFound();
        //    return NoContent();
        //}
    }
}
