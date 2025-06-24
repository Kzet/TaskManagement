using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Application.Security;
using TaskManagement.Domain.Configs;

namespace TaskManagement.Infrastructure.Security
{
    public class JwtManager : IJwtManager
    {
        private readonly JwtConfig authOptions;
        private readonly byte[] secret;
        private readonly byte[] refreshTokenSecret;

        public JwtManager(JwtConfig authOptions)
        {
            this.authOptions = authOptions;
            secret = Encoding.ASCII.GetBytes(authOptions.Secret);
            refreshTokenSecret = Encoding.ASCII.GetBytes(authOptions.RefreshTokenSecret);
        }

        public string GenerateToken(string username, IEnumerable<Claim> claims, DateTime now)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                authOptions.Issuer,
                shouldAddAudienceClaim ? authOptions.Audience : string.Empty,
                claims,
                DateTime.Now,
                expires: now.AddMinutes(authOptions.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public string GenerateRefreshTokens(string username, DateTime now)
        {
            var jwtToken = new JwtSecurityToken(
                authOptions.Issuer,
                authOptions.Audience,
                null,
                DateTime.Now,
                expires: now.AddMinutes(authOptions.RefreshTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(refreshTokenSecret), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }


        public bool ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Secret)),
                ValidIssuer = authOptions.Issuer,
                ValidAudience = authOptions.Audience,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            try
            {
                jwtSecurityTokenHandler.ValidateToken(token, validationParameters,
                    out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ValidateRefreshToken(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.RefreshTokenSecret)),
                ValidIssuer = authOptions.Issuer,
                ValidAudience = authOptions.Audience,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters,
                    out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
