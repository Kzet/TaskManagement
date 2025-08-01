using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.ProjectEntities;

namespace TaskManagement.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsByStatus(string userId, int statusId, CancellationToken ct);
        Task<List<Project>> GetProjects(string userId, CancellationToken ct);
    }
}
