using MediatR;

namespace ELearning.Application.Compiler.Commands.SaveAssignmentSolution
{
    public class SaveAssignmentSolutionCommand : IRequest
    {
        public int AssignmentId { get; set; }
        public string Solution { get; set; }
    }
}
