using FluentValidation;

namespace ELearning.Application.Users.Queries.GetUserPastAssignmentsListById
{
    public class GetUserPastAssignmentsListByIdQueryValidator : AbstractValidator<GetUserPastAssignmentsListByIdQuery>
    {
        public GetUserPastAssignmentsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
