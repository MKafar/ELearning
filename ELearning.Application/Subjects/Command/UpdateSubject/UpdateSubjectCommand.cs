using MediatR;

namespace ELearning.Application.Subjects.Command.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; }
    }
}
