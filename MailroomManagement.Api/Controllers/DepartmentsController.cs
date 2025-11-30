using MailroomManagement.Api.Models.Requests.Departments;
using MailroomManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailroomManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments([FromQuery] int organizationId)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync(organizationId);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            var department = await _departmentService.CreateDepartmentAsync(request, CurrentUserName);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentRequest request)
        {
            var department = await _departmentService.UpdateDepartmentAsync(id, request, CurrentUserName);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id, CurrentUserName);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
