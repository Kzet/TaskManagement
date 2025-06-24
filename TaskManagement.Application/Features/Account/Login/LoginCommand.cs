using MediatR;

namespace TaskManagement.Application.Features.Account.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResult>;
}
