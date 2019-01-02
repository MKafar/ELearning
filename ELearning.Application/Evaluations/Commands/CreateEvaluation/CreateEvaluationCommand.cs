using MediatR;

namespace ELearning.Application.Evaluations.Commands.CreateEvaluation
{
    public class CreateEvaluationCommand : IRequest
    {
        public int AssignmentId { get; set; }
        public int SectionId { get; set; }
        public double Grade { get; set; }
    }
}
