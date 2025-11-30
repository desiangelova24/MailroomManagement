using MailroomManagement.Api.Models.Requests.Auth;
using MailroomManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MailroomManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Auth/register
        ///     {
        ///         "username": "john.doe",
        ///         "email": "john.doe@example.com",
        ///         "password": "Admin@123",
        ///         "organizationId": 1,
        ///         "departmentId": 1
        ///     }
        ///     * Use /api/Organizations/with-departments to see exist Organisations 
        /// </remarks>
        /// <param name="request">The request containing the user details.</param>
        /// <returns>The result of the registration operation.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.Register(request);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Auth/login
        ///     {
        ///         "email": "john.doe@example.com",
        ///         "password": "Admin@123"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">The request containing the login details.</param>
        /// <returns>The result of the login operation.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request);
            if (!result.Success)
                return Unauthorized(result.Message);
            return Ok(result);
        }
    }
}
