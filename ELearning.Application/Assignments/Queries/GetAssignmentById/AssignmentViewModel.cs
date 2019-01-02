namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int VariantId { get; set; }
        public int VariantNumber { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseTitle { get; set; }
        public int SectionId { get; set; }
        public int SectionNumber { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectAbreviation { get; set; }
    }
}
