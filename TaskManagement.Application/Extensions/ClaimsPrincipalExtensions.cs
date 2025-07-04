using System.Security.Claims;

namespace TaskManagement.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Name);
        }
    }
}
