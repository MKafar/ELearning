using FluentValidation;

namespace ELearning.Application.Assignments.Queries.GetAssignmentEvaluationsListById
{
    public class GetAssignmentEvaluationsListByIdQueryValidator : AbstractValidator<GetAssignmentEvaluationsListByIdQuery>
    {
        public GetAssignmentEvaluationsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
