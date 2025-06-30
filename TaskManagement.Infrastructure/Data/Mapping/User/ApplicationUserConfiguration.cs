using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Infrastructure.Data.Mapping.User
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(_ => _.Projects)
                .WithOne(_ => _.Owner)
                .HasForeignKey(_ => _.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(_ => _.Tasks)
                .WithOne(_ => _.Owner)
                .HasForeignKey(_ => _.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
