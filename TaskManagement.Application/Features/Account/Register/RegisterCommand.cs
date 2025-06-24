using MediatR;

namespace TaskManagement.Application.Features.Account.Register
{
    public record RegisterCommand(string Email, string Password) : IRequest<RegisterResult>;
}
