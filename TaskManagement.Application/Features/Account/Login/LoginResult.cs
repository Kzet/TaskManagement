namespace TaskManagement.Application.Features.Account.Login
{
    public record LoginResult(string Token, string RefreshToken, string UserId, string Email);
}
