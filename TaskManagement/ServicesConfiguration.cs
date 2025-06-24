using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Behaviors;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Application.Security;
using TaskManagement.Domain.Entities.UserEntities;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Security;

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
            services.AddSingleton<IJwtManager, JwtManager>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginHandler>());
            services.AddAutoMapper(typeof(Program));

            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
