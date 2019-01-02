using ELearning.Application.Evaluations.Models;
using MediatR;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListByAssignmentId
{
    public class GetEvaluationsListByAssignmentIdQuery : IRequest<EvaluationsListViewModel>
    {
        public int Id { get; set; }
    }
}
