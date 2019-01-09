namespace ELearning.Application.Users.Queries.GetPastAssignmentsListById
{
    public class PastAssignmentLookupModel
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }

        public string ExerciseTitle { get; set; }

        public string GroupName { get; set; }
    }
}
