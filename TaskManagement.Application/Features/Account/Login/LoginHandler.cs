using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using TaskManagement.Application.Security;
using TaskManagement.Domain.Entities.UserEntities;

namespace TaskManagement.Application.Features.Account.Login
{
    public class LoginHandler(
    UserManager<ApplicationUser> userManager,
    IJwtManager jwtManager,
    IConfiguration configuration)
    : IRequestHandler<LoginCommand, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken ct)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                throw new Exception("Invalid credentials");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email!)
            };

            var token = jwtManager.GenerateToken(user.UserName, claims, DateTime.Now);
            var refreshToken = jwtManager.GenerateRefreshTokens(user.UserName, DateTime.Now);


            return new LoginResult(token, refreshToken, user.Id, user.Email!);
        }
    }
}
