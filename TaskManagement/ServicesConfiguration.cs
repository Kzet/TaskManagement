using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.UserEntities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement
{
    public static class ServicesConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

        }

        public static void AddCustomServices(this IServiceCollection services)
        {

        }
    }
}
