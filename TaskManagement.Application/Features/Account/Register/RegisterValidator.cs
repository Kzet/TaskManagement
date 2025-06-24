using FluentValidation;

namespace TaskManagement.Application.Features.Account.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6).NotEmpty();
        }
    }
}
