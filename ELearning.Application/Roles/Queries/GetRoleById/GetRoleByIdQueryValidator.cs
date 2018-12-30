using FluentValidation;

namespace ELearning.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
