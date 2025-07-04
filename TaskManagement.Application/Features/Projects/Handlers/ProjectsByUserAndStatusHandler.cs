using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Application.Features.Projects.Dtos;

namespace TaskManagement.Application.Features.Projects.Handlers
{
    public class ProjectsByUserAndStatusHandler : IRequestHandler<ProjectsByUserAndStatusCommand, IEnumerable<ProjectDto>>
    {
        private readonly IMapper _mapper;

        public ProjectsByUserAndStatusHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(ProjectsByUserAndStatusCommand request, CancellationToken ct)
        {
            return await _context.Projects
                .Where(p => p.UserId == request.UserId && p.Status == request.Status)
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);
        }
    }
}
