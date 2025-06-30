using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.Core;
using TaskManagement.Domain.Entities.ProjectEntities;

namespace TaskManagement.Domain.Entities.StatusEntities
{
    public class ProjectStatus : BaseIntModel
    {

        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
