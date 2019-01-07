using MediatR;

namespace ELearning.Application.Users.Queries.GetStudentsList
{
    public class GetStudentsListQuery : IRequest<StudentsListViewModel>
    {
    }
}
