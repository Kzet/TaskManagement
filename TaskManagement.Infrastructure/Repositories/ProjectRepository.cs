using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Features.Projects.Dtos;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectsByStatus(string userId, int statusId, CancellationToken ct)
        {
            return await _context.Projects
                .Where(p => p.OwnerId == userId && p.StatusId == statusId)
                .ToListAsync(ct);
        }

        public async Task<List<Project>> GetProjects(string userId, CancellationToken ct)
        {
            return await _context.Projects
                .Where(p => p.OwnerId == userId)
                .ToListAsync(ct);
        }
    }
}
