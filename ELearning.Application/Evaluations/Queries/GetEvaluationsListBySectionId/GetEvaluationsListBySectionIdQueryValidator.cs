using FluentValidation;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListBySectionId
{
    public class GetEvaluationsListBySectionIdQueryValidator : AbstractValidator<GetEvaluationsListBySectionIdQuery>
    {
        public GetEvaluationsListBySectionIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
