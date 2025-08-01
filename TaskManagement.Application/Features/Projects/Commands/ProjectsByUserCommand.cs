using MediatR;
using TaskManagement.Application.Features.Projects.Dtos;

namespace TaskManagement.Application.Features.Account.Login
{
    public record ProjectsByUserCommand(string UserId) : IRequest<IEnumerable<ProjectDto>>;
}
