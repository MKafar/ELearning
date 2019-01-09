using FluentValidation;

namespace ELearning.Application.Users.Queries.GetSectionsListById
{
    public class GetSectionsListByIdQueryValidator : AbstractValidator<GetSectionsListByIdQuery>
    {
        public GetSectionsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
