using MediatR;

namespace ELearning.Application.Subjects.Command.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
