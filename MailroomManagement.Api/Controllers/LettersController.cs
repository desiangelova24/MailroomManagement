using MailroomManagement.Api.Models.Requests.Letters;
using MailroomManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MailroomManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LettersController :BaseController
    {
        private readonly ILetterService _letterService;

        public LettersController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLetters()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var letters = await _letterService.GetLettersByUserId(userId);
            return Ok(letters);
        }

        [HttpPost]
        public async Task<IActionResult> SendLetter([FromBody] CreateLetterRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _letterService.SendLetter(request, userId, CurrentUserName);
            return CreatedAtAction(nameof(GetLetter), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLetter(int id)
        {
            var letter = await _letterService.GetLetterById(id);
            if (letter == null)
                return NotFound();
            return Ok(letter);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateLetterStatus(int id, [FromBody] UpdateLetterStatusRequest request)
        {
            var result = await _letterService.UpdateLetterStatus(id, request.Status, CurrentUserName);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
