using MediatR;

namespace ELearning.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
