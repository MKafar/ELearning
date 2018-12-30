using MediatR;

namespace ELearning.Application.Subjects.Command.CreateSubject
{
    public class CreateSubjectCommand : IRequest
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
    }
}
