using FluentValidation;

namespace ELearning.Application.Sections.Queries.GetSectionEvaluationsListById
{
    public class GetSectionEvaluationsListByIdQueryValidator : AbstractValidator<GetSectionEvaluationsListByIdQuery>
    {
        public GetSectionEvaluationsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
