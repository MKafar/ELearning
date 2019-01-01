using FluentValidation;

namespace ELearning.Application.Sections.Queries.GetSectionById
{
    public class GetSectionByIdQueryValidator : AbstractValidator<GetSectionByIdQuery>
    {
        public GetSectionByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
