using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.Core;
using TaskManagement.Domain.Entities.ProjectEntities;

namespace TaskManagement.Domain.Entities.StatusEntities
{
    public class Priority : BaseIntModel
    {
        public int Order { get; set; }


        [JsonIgnore]
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
