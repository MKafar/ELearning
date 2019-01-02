using MediatR;

namespace ELearning.Application.Evaluations.Commands.UpdateEvaluation
{
    public class UpdateEvaluationCommand : IRequest
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int SectionId { get; set; }
        public double Grade { get; set; }
    }
}
