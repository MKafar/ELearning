using MediatR;

namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQuery : IRequest<AssignmentViewModel>
    {
        public int Id { get; set; }
    }
}
