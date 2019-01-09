using MediatR;

namespace ELearning.Application.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommand : IRequest
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int VariantId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double FinalGrade { get; set; }
    }
}
