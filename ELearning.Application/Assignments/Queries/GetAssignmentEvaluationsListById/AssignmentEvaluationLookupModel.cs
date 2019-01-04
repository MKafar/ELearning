namespace ELearning.Application.Assignments.Queries.GetAssignmentEvaluationsListById
{
    public class AssignmentEvaluationLookupModel
    {
        public int AssignmentBeingEvaluatedId { get; set; }
        public int SectionWhichEvaluatesId { get; set; }
        public int EvaluationId { get; set; }
        public double Grade { get; set; }
    }
}
