using FluentValidation;

namespace ELearning.Application.Sections.Commands.CreateSection
{
    public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
    {
        public CreateSectionCommandValidator()
        {
            RuleFor(v => v.GroupId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.UserId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.Number)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(32767);
        }
    }
}
