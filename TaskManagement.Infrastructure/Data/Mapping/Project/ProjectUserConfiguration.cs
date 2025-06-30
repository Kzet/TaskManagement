using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.ToTable("ProjectUsers");
            builder.HasKey(sc => new { sc.UserId, sc.ProjectId });
        }
    }
}
