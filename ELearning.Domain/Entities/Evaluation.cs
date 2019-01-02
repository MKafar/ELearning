namespace ELearning.Domain.Entities
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public double Grade { get; set; }

        public int AssignmentId { get; set; }
        public Assignment EvaluatedAssignment { get; set; }

        public int SectionId { get; set; }
        public Assignment EvaluatorAssignment { get; set; }
    }
}
