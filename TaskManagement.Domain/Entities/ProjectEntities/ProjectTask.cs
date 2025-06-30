using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.Core;
using TaskManagement.Domain.Entities.StatusEntities;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Domain.Entities.ProjectEntities
{
    public class ProjectTask : BaseGuidModel
    {
        public string Description { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public int StatusId { get; set; }
        public Priority Priority { get; set; }
        public int PriorityId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndedDate { get; set; }


        [JsonIgnore]
        public virtual ICollection<ProjectTaskUser> ProjectTaskUsers { get; set; }

    }
}
