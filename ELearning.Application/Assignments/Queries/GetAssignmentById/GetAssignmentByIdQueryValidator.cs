using FluentValidation;

namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQueryValidator : AbstractValidator<GetAssignmentByIdQuery>
    {
        public GetAssignmentByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
