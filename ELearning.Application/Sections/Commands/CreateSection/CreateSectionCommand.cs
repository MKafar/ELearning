using MediatR;

namespace ELearning.Application.Sections.Commands.CreateSection
{
    public class CreateSectionCommand : IRequest
    {
        public int Number { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
