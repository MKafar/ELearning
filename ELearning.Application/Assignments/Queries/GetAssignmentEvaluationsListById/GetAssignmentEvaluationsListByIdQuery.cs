using MediatR;

namespace ELearning.Application.Assignments.Queries.GetAssignmentEvaluationsListById
{
    public class GetAssignmentEvaluationsListByIdQuery : IRequest<AssignmentEvaluationsListViewModel>
    {
        public int Id { get; set; }
    }
}
