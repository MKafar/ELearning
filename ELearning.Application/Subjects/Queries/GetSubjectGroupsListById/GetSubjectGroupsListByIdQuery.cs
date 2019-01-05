using MediatR;

namespace ELearning.Application.Subjects.Queries.GetSubjectGroupsListById
{
    public class GetSubjectGroupsListByIdQuery : IRequest<SubjectGroupsListViewModel>
    {
        public int Id { get; set; }
    }
}
