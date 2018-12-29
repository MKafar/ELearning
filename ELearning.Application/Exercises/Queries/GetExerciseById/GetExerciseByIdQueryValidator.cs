using FluentValidation;

namespace ELearning.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdQueryValidator : AbstractValidator<GetExerciseByIdQuery>
    {
        public GetExerciseByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
