using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectTaskUserConfiguration : IEntityTypeConfiguration<ProjectTaskUser>
    {
        public void Configure(EntityTypeBuilder<ProjectTaskUser> builder)
        {
            builder.ToTable("ProjectTaskUsers");
            builder.HasKey(sc => new { sc.UserId, sc.TaskId });
        }
    }
}
