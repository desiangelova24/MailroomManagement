using MailroomManagement.Api.Models.Requests.Setup;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Data.MailroomManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace MailroomManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _setupService;

        public SetupController(ISetupService setupService)
        {
            _setupService = setupService;
        }

        [HttpPost("initialize")]
        public async Task<IActionResult> Initialize([FromBody] InitializeRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            var response = await _setupService.InitializeAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }
    }
}
