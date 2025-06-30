using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder.ToTable("ProjectStatuses");
            builder.HasKey(_ => _.Id);

            builder.HasMany(_ => _.Projects)
                .WithOne(_ => _.Status)
                .HasForeignKey(_ => _.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
