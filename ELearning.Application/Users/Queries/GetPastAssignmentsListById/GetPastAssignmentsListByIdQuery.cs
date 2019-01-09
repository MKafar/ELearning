using MediatR;

namespace ELearning.Application.Users.Queries.GetPastAssignmentsListById
{
    public class GetPastAssignmentsListByIdQuery : IRequest<PastAssignmentsListViewModel>
    {
        public int Id { get; set; }
    }
}
