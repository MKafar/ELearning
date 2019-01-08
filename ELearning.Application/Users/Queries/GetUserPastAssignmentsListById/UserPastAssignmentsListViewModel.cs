using System.Collections.Generic;

namespace ELearning.Application.Users.Queries.GetUserPastAssignmentsListById
{
    public class UserPastAssignmentsListViewModel
    {
        public IList<UserPastAssignmentLookupModel> PastAssignments { get; set; }
    }
}
