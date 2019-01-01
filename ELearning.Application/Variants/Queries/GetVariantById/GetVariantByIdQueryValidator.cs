using FluentValidation;

namespace ELearning.Application.Variants.Queries.GetVariantById
{
    public class GetVariantByIdQueryValidator : AbstractValidator<GetVariantByIdQuery>
    {
        public GetVariantByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
