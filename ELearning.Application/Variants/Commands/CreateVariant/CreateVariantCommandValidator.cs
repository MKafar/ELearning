using FluentValidation;

namespace ELearning.Application.Variants.Commands.CreateVariant
{
    public class CreateVariantCommandValidator : AbstractValidator<CreateVariantCommand>
    {
        public CreateVariantCommandValidator()
        {
            RuleFor(v => v.Content)
                .NotEmpty();

            RuleFor(v => v.Number)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(255);

            RuleFor(v => v.ExerciseId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
