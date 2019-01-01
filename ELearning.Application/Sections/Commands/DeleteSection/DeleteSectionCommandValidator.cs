using FluentValidation;

namespace ELearning.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
