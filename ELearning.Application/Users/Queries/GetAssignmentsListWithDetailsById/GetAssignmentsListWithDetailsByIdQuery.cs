using MediatR;

namespace ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById
{
    public class GetAssignmentsListWithDetailsByIdQuery : IRequest<AssignmentsListWithDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
