using FluentValidation;

namespace ELearning.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

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
                .WithMessage("University's email has format {login@student.polsl.pl} or {name.surname@polsl.pl}.");

            RuleFor(v => v.RoleId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
