using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.ProjectEntities;
using TaskManagement.Domain.Entities.StatusEntities;
using TaskManagement.Domain.Entities.UserEntities;
using TaskManagement.Infrastructure.Data.Mapping.User;

namespace TaskManagement.Infrastructure.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasData(new Priority
            {
                Id = 1,
                Name = "Низкий",
                Order = 3,
            });
            modelBuilder.Entity<Priority>().HasData(new Priority
            {
                Id = 2,
                Name = "Средний",
                Order = 2,
            });
            modelBuilder.Entity<Priority>().HasData(new Priority
            {
                Id = 3,
                Name = "Высокий",
                Order = 1,
            });

            modelBuilder.Entity<ProjectTaskStatus>().HasData(new ProjectTaskStatus
            {
                Id = 1,
                Name = "В работе"
            });
            modelBuilder.Entity<ProjectTaskStatus>().HasData(new ProjectTaskStatus
            {
                Id = 2,
                Name = "Завершено"
            });
            modelBuilder.Entity<ProjectTaskStatus>().HasData(new ProjectTaskStatus
            {
                Id = 3,
                Name = "Ожидание"
            });

            modelBuilder.Entity<ProjectStatus>().HasData(new ProjectStatus
            {
                Id = 1,
                Name = "В разработке",
            });
            modelBuilder.Entity<ProjectStatus>().HasData(new ProjectStatus
            {
                Id = 2,
                Name = "Завершен",
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Priority> Priorities { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectTaskStatus> ProjectTaskStatuses { get; set; }
        public DbSet<ProjectTaskUser> ProjectTaskUsers { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}
