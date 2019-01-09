using MediatR;

namespace ELearning.Application.Assignments.Queries.GetPresentNotEvaluatedAssignmentsListById
{
    public class GetPresentNotEvaluatedAssignmentsListQuery : IRequest<PresentNotEvaluatedAssignmentsListViewModel>
    {
        public int Id { get; set; }
    }
}
