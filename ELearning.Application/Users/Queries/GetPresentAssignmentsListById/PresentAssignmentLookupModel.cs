using System;

namespace ELearning.Application.Users.Queries.GetPresentAssignmentsListById
{
    public class PresentAssignmentLookupModel
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime DateTime { get; set; }

        public int ExerciseId { get; set; }
        public string ExerciseTitle { get; set; }

        public int VariantId { get; set; }
        public string Content { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
