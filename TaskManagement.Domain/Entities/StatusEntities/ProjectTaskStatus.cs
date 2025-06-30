using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.Core;
using TaskManagement.Domain.Entities.ProjectEntities;

namespace TaskManagement.Domain.Entities.StatusEntities
{
    public class ProjectTaskStatus : BaseIntModel
    {

        [JsonIgnore]
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
