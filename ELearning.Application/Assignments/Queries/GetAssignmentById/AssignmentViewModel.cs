namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Solution { get; set; }
        public double? FinalGrade { get; set; }

        public int VariantId { get; set; }
        public string Content { get; set; }

        public string ExerciseTitle { get; set; }
    }
}
