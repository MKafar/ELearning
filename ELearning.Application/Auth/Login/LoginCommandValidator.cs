using FluentValidation;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Login)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(v => v.Password)
                .NotEmpty()
                .MaximumLength(16);
        }
    }
}
