using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Application.Features.Account.Register;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }
    }
}
