using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.Core;
using TaskManagement.Domain.Entities.StatusEntities;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Domain.Entities.ProjectEntities
{
    public class Project : BaseGuidModel
    {
        public string Description { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public ProjectStatus Status { get; set; }
        public int StatusId { get; set; }



        [JsonIgnore]
        public virtual ICollection<ProjectTask> Tasks { get; set; }


        [JsonIgnore]
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

    }
}
