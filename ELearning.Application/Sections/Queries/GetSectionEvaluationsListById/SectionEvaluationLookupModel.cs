namespace ELearning.Application.Sections.Queries.GetSectionEvaluationsListById
{
    public class SectionEvaluationLookupModel
    {
        public int SectionWhichEvaluatesId { get; set; }
        public int AssignmentBeingEvaluatedId { get; set; }
        public int EvaluationId { get; set; }
        public double Grade { get; set; }
    }
}
