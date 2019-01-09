using MediatR;

namespace ELearning.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommand : IRequest
    {
        public int SectionId { get; set; }
        public int VariantId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
