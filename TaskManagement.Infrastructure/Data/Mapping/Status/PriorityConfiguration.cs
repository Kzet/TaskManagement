using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities.StatusEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.ToTable("Priorities");
            builder.HasKey(_ => _.Id);

            builder.HasMany(_ => _.Tasks)
                .WithOne(_ => _.Priority)
                .HasForeignKey(_ => _.PriorityId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
