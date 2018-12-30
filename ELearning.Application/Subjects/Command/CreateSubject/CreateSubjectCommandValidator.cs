using FluentValidation;

namespace ELearning.Application.Subjects.Command.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(v => v.Abreviation)
                .NotEmpty()
                .MaximumLength(8);
        }
    }
}
