using MediatR;

namespace ELearning.Application.Users.Queries.GetUserSectionsListById
{
    public class GetUserSectionsListByIdQuery : IRequest<UserSectionsListViewModel>
    {
        public int Id { get; set; }
    }
}
