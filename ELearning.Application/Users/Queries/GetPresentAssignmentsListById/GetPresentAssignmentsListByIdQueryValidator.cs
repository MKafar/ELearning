using FluentValidation;

namespace ELearning.Application.Users.Queries.GetPresentAssignmentsListById
{
    public class GetPresentAssignmentsListByIdQueryValidator : AbstractValidator<GetPresentAssignmentsListByIdQuery>
    {
        public GetPresentAssignmentsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
