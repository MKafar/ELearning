using FluentValidation;

namespace ELearning.Application.Variants.Commands.DeleteVariant
{
    public class DeleteVariantCommandValidator : AbstractValidator<DeleteVariantCommand>
    {
        public DeleteVariantCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
