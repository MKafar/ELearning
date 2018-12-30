using MediatR;

namespace ELearning.Application.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQuery : IRequest<SubjectViewModel>
    {
        public int Id { get; set; }
    }
}
