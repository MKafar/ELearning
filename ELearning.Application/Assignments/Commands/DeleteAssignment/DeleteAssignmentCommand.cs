using MediatR;

namespace ELearning.Application.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
