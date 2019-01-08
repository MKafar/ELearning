using FluentValidation;

namespace ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById
{
    public class GetAssignmentsListWithDetailsByIdQueryValidator : AbstractValidator<GetAssignmentsListWithDetailsByIdQuery>
    {
        public GetAssignmentsListWithDetailsByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
