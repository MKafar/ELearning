namespace ELearning.Application.Evaluations.Models
{
    public class EvaluationLookupModel
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int SectionId { get; set; }
        public double Grade { get; set; }
    }
}
