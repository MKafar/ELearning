using FluentValidation;

namespace ELearning.Application.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQueryValidator : AbstractValidator<GetSubjectByIdQuery>
    {
        public GetSubjectByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
