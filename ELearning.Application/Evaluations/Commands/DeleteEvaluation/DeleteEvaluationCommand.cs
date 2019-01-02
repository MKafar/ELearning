using MediatR;

namespace ELearning.Application.Evaluations.Commands.DeleteEvaluation
{
    public class DeleteEvaluationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
