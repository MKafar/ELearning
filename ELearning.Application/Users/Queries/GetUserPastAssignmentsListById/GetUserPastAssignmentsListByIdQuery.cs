using MediatR;

namespace ELearning.Application.Users.Queries.GetUserPastAssignmentsListById
{
    public class GetUserPastAssignmentsListByIdQuery : IRequest<UserPastAssignmentsListViewModel>
    {
        public int Id { get; set; }
    }
}
