using FluentValidation;

namespace ELearning.Application.Users.Queries.GetUserSectionsListById
{
    public class GetUserSectionsListByIdQueryValidator : AbstractValidator<GetUserSectionsListByIdQuery>
    {
        public GetUserSectionsListByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
