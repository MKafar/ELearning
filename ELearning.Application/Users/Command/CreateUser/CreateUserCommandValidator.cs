using FluentValidation;

namespace ELearning.Application.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[A-ZĄĆĘŁŃÓŚŹŻ]([a-ząćęłńóśźż0-9_-]{1,}|)$")
                .WithMessage("Name should have one upper case letter at the start.");

            RuleFor(v => v.Surname)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[A-ZĄĆĘŁŃÓŚŹŻ]([a-ząćęłńóśźż0-9_-]{1,}|)$")
                .WithMessage("Surname should have one upper case letter at the start.");

            RuleFor(v => v.Email)
                .NotEmpty()
                .MaximumLength(320)
                .Matches("^.{1,64}@student.polsl.pl$")
                .WithMessage("University's email has format {login@student.polsl.pl} or {name.surname@student.polsl.pl}.");
        }
    }
}
