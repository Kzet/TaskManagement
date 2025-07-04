using MediatR;
using TaskManagement.Application.Features.Projects.Dtos;

namespace TaskManagement.Application.Features.Account.Login
{
    public record ProjectsByUserAndStatusCommand(string UserId, int StatusId) : IRequest<ProjectDto>;
}
