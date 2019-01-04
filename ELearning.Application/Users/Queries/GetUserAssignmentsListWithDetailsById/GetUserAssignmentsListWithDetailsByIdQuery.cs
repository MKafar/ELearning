using MediatR;

namespace ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById
{
    public class GetUserAssignmentsListWithDetailsByIdQuery : IRequest<UserAssignmentsListWithDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
