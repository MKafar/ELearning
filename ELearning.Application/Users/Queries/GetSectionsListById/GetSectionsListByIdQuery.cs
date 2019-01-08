using MediatR;

namespace ELearning.Application.Users.Queries.GetSectionsListById
{
    public class GetSectionsListByIdQuery : IRequest<SectionsListViewModel>
    {
        public int Id { get; set; }
    }
}
