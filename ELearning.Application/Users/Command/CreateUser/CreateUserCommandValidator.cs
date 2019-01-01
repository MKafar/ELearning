using FluentValidation;

namespace ELearning.Application.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(v => v.Surname)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(v => v.Email)
                .NotEmpty()
                .MaximumLength(320)
                .Matches("^.{1,64}@(student.|)polsl.pl$")
                .WithMessage("University's email has format {login@student.polsl.pl} or {name.surname@student.polsl.pl}.");
        }
    }
}
