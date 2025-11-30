using MailroomManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MailroomManagement.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string CurrentUserName => User.Identity?.Name ?? "System";
    }
}
