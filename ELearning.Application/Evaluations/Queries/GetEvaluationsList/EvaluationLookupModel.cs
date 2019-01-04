namespace ELearning.Application.Evaluations.Queries.GetEvaluationsList
{
    public class EvaluationLookupModel
    {
        public int EvaluationId { get; set; }
        public int AssignmentBeingEvaluatedId { get; set; }
        public int SectionWhichEvaluatesId { get; set; }
        public double Grade { get; set; }
    }
}
