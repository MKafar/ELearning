using MediatR;

namespace ELearning.Application.Users.Queries.GetSectionsListById
{
    public class GetSectionsListByIdQuery : IRequest<SectionsDetailedListViewModel>
    {
        public int Id { get; set; }
    }
}
