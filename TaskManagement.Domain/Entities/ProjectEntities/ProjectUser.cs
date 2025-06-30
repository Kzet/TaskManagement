using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Domain.Entities.ProjectEntities
{
    public class ProjectUser
    {
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
