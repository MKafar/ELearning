namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int VariantId { get; set; }
        public int SectionId { get; set; }
        public string Content { get; set; }
    }
}
