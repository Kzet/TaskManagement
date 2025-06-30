using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectTaskStatusConfiguration : IEntityTypeConfiguration<ProjectTaskStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectTaskStatus> builder)
        {
            builder.ToTable("ProjectTaskStatuses");
            builder.HasKey(_ => _.Id);

            builder.HasMany(_ => _.Tasks)
                .WithOne(_ => _.Status)
                .HasForeignKey(_ => _.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
