using FluentValidation;

namespace ELearning.Application.Assignments.Queries.GetPresentNotEvaluatedAssignmentsListById
{
    public class GetPresentNotEvaluatedAssignmentsListQueryValidator : AbstractValidator<GetPresentNotEvaluatedAssignmentsListQuery>
    {
        public GetPresentNotEvaluatedAssignmentsListQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
