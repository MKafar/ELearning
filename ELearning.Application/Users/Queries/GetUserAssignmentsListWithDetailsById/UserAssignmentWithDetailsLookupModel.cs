namespace ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById
{
    public class UserAssignmentWithDetailsLookupModel
    {
        public int AssignmentId { get; set; }
        public string AssignmentDate { get; set; }
        public double? AssignmentFinalGrade { get; set; }
        public int UserId { get; set; }
        public int VariantId { get; set; }
        public int VariantNumber { get; set; }
        public string ExerciseTitle { get; set; }
        public int SectionId { get; set; }
        public string GroupName { get; set; }
    }
}
