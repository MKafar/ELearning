using MediatR;

namespace ELearning.Application.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQuery : IRequest<GroupViewModel>
    {
        public int Id { get; set; }
    }
}
