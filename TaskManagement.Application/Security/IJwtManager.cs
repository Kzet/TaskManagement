using System.Security.Claims;

namespace TaskManagement.Application.Security
{
    public interface IJwtManager
    {
        string GenerateToken(string username, IEnumerable<Claim> claims, DateTime now);
        string GenerateRefreshTokens(string username, DateTime now);
        bool ValidateToken(string token);
        bool ValidateRefreshToken(string refreshToken);
    }
}
