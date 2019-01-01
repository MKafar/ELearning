using MediatR;

namespace ELearning.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest
    {
        public string Name { get; set; }
        public int AcademicYear { get; set; }
        public int SubjectId { get; set; }
    }
}
