using System.Collections.Generic;

namespace ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById
{
    public class UserAssignmentsListWithDetailsViewModel
    {
        public IList<UserAssignmentWithDetailsLookupModel> AssignmentsWithDetails { get; set; }
    }
}
