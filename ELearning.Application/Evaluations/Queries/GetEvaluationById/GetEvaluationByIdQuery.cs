using MediatR;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationById
{
    public class GetEvaluationByIdQuery : IRequest<EvaluationViewModel>
    {
        public int Id { get; set; }
    }
}
