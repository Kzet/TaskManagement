using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Behaviors;
using TaskManagement.Application.Features.Account.Login;
using TaskManagement.Application.Features.Account.Register;
using TaskManagement.Application.Security;
using TaskManagement.Domain.Entities.UserEntities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;
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
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginHandler>());
            services.AddAutoMapper(typeof(Program));

            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
