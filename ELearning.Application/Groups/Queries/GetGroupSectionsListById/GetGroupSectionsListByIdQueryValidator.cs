using FluentValidation;

namespace ELearning.Application.Groups.Queries.GetGroupSectionsListById
{
    public class GetGroupSectionsListByIdQueryValidator : AbstractValidator<GetGroupSectionsListByIdQuery>
    {
        public GetGroupSectionsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
