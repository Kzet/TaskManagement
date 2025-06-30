using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Domain.Entities.ProjectEntities
{
    public class ProjectTaskUser
    {
        public ProjectTask Task { get; set; }
        public Guid TaskId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
