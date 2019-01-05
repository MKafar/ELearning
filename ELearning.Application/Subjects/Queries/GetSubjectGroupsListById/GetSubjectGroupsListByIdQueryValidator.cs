using FluentValidation;

namespace ELearning.Application.Subjects.Queries.GetSubjectGroupsListById
{
    public class GetSubjectGroupsListByIdQueryValidator : AbstractValidator<GetSubjectGroupsListByIdQuery>
    {
        public GetSubjectGroupsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
