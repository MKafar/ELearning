using FluentValidation;

namespace ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById
{
    public class GetUserAssignmentsListWithDetailsByIdQueryValidator : AbstractValidator<GetUserAssignmentsListWithDetailsByIdQuery>
    {
        public GetUserAssignmentsListWithDetailsByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
