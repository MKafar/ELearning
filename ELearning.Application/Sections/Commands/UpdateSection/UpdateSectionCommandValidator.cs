using FluentValidation;

namespace ELearning.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

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
