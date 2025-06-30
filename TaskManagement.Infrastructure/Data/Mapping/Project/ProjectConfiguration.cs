using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(_ => _.Id);

            builder.HasMany(_ => _.Tasks)
                .WithOne(_ => _.Project)
                .HasForeignKey(_ => _.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
