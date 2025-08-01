using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Application.Features.Projects.Dtos;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Projects.Handlers
{
    public class ProjectsByUserHandler : IRequestHandler<ProjectsByUserCommand, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsByUserHandler(IMapper mapper,
            IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(ProjectsByUserCommand request, CancellationToken ct)
        {
            var projects = await _projectRepository.GetProjects(request.UserId, ct);
            return _mapper.Map<List<ProjectDto>>(projects);
        }
    }
}
