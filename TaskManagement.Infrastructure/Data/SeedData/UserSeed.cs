using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Infrastructure.Data.SeedData
{
    public static class UserSeed
    {
        public static async Task SeedDefaultUsersAsync(
        UserManager<ApplicationUser> userManager)
        {
            var admUser = new ApplicationUser
            {
                UserName = "admin@task.com",
                Email = "admin@task.com"
            };

            var adminExists = await userManager.FindByEmailAsync(admUser.Email!);
            if (adminExists == null)
            {
                var res = await userManager.CreateAsync(admUser, "Qwerty123!tfgs"); // Создаем пользователя
                Console.WriteLine(res);
            }
        }
    }
}
