using FluentValidation;

namespace ELearning.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
    {
        public UpdateExerciseCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.Title)
                .NotEmpty()
                .MaximumLength(64);
        }
    }
}
