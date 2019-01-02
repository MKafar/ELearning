using ELearning.Application.Evaluations.Models;
using MediatR;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListBySectionId
{
    public class GetEvaluationsListBySectionIdQuery : IRequest<EvaluationsListViewModel>
    {
        public int Id { get; set; }
    }
}
