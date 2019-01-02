namespace ELearning.Application.Assignments.Queries.GetAssignmentsList
{
    public class AssignmentLookupModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int VariantId { get; set; }
        public int SectionId { get; set; }
    }
}
