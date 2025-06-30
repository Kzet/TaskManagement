using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using TaskManagement.Domain.Entities.ProjectEntities;

namespace TaskManagement.Domain.Entities.UserEntities
{
    public class ApplicationUser : IdentityUser
    {

        [JsonIgnore]
        public virtual ICollection<ProjectTask> Tasks { get; set; }

        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectTaskUser> ProjectTaskUsers { get; set; }

    }
}
