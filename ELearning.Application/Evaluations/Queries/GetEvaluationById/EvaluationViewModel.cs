namespace ELearning.Application.Evaluations.Queries.GetEvaluationById
{
    public class EvaluationViewModel
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int SectionId { get; set; }
        public double Grade { get; set; }
    }
}
