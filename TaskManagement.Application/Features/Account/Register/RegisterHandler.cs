using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Application.Features.Account.Register
{
    public class RegisterHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<RegisterCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken ct)
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return new RegisterResult(Guid.Parse(user.Id), user.Email!);
        }
    }
}
