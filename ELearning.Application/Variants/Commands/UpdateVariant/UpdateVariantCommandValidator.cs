using FluentValidation;

namespace ELearning.Application.Variants.Commands.UpdateVariant
{
    public class UpdateVariantCommandValidator : AbstractValidator<UpdateVariantCommand>
    {
        public UpdateVariantCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

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
