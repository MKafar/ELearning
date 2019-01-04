using FluentValidation;

namespace ELearning.Application.Exercises.Queries.GetExerciseVariantsListById
{
    public class GetExerciseVariantsListByIdQueryValidator : AbstractValidator<GetExerciseVariantsListByIdQuery>
    {
        public GetExerciseVariantsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
