using FluentValidation;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListByAssignmentId
{
    public class GetEvaluationsListByAssignmentIdQueryValidator : AbstractValidator<GetEvaluationsListByAssignmentIdQuery>
    {
        public GetEvaluationsListByAssignmentIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
