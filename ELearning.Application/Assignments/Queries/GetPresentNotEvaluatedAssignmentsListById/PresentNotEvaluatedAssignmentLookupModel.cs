using ELearning.Domain.Entities;
using System.Collections.Generic;

namespace ELearning.Application.Assignments.Queries.GetPresentNotEvaluatedAssignmentsListById
{
    public class PresentNotEvaluatedAssignmentLookupModel
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public string Solution { get; set; }

        public int GroupId { get; set; }
    }
}
