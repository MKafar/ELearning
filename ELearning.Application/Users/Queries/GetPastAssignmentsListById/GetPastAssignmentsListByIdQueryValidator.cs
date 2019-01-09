using FluentValidation;

namespace ELearning.Application.Users.Queries.GetPastAssignmentsListById
{
    public class GetPastAssignmentsListByIdQueryValidator : AbstractValidator<GetPastAssignmentsListByIdQuery>
    {
        public GetPastAssignmentsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
