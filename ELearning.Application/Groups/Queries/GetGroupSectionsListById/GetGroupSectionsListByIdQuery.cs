using MediatR;

namespace ELearning.Application.Groups.Queries.GetGroupSectionsListById
{
    public class GetGroupSectionsListByIdQuery : IRequest<GroupSectionsListViewModel>
    {
        public int Id { get; set; }
    }
}
