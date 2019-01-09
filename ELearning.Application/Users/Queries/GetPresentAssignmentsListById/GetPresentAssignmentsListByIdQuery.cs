using MediatR;

namespace ELearning.Application.Users.Queries.GetPresentAssignmentsListById
{
    public class GetPresentAssignmentsListByIdQuery : IRequest<PresentAssignmentsListViewModel>
    {
        public int Id { get; set; }
    }
}
