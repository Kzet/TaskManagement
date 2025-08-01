using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProjectController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsByStatus(int statusId)
        {
            var user = await _userManager.FindByNameAsync(User.GetLoggedInUserName());
            var query = new ProjectsByUserAndStatusCommand(user.Id, statusId);

            var projects = await _mediator.Send(query);
            return Ok(projects);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var user = await _userManager.FindByNameAsync(User.GetLoggedInUserName());
            var query = new ProjectsByUserCommand(user.Id);

            var projects = await _mediator.Send(query);
            return Ok(projects);
        }

    }
}
