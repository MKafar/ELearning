using MediatR;

namespace ELearning.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int Number { get; set; }
    }
}
