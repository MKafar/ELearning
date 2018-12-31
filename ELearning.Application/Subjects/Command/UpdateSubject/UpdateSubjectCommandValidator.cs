using FluentValidation;

namespace ELearning.Application.Subjects.Command.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
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
