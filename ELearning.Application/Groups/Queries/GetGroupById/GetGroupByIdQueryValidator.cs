using FluentValidation;

namespace ELearning.Application.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQueryValidator : AbstractValidator<GetGroupByIdQuery>
    {
        public GetGroupByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
