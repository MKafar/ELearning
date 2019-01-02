using FluentValidation;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationById
{
    public class GetEvaluationByIdQueryValidator : AbstractValidator<GetEvaluationByIdQuery>
    {
        public GetEvaluationByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
