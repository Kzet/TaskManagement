using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.ToTable("ProjectTasks");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.CreatedDate).IsRequired();
            builder.Property(_ => _.EndedDate).IsRequired();
        }
    }
}
