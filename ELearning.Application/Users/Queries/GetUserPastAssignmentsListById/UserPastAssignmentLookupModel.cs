namespace ELearning.Application.Users.Queries.GetUserPastAssignmentsListById
{
    public class UserPastAssignmentLookupModel
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public string Solution { get; set; }
        public double? FinalGrade { get; set; }

        public int ExerciseId { get; set; }
        public string ExerciseTitle { get; set; }

        public int VariantId { get; set; }
        public string Content { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
