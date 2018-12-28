namespace ELearning.Domain.Entities
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public decimal Grade { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public int SectionId { get; set; }
        public Assignment Section { get; set; }
    }
}
