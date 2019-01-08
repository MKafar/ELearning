using System.Collections.Generic;

namespace ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById
{
    public class AssignmentsListWithDetailsViewModel
    {
        public IList<AssignmentWithDetailsLookupModel> UserAssignmentsWithDetails { get; set; }
    }
}
