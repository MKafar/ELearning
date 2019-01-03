namespace ELearning.Application.Users.Queries.GetUserSectionsListById
{
    public class UserSectionsLookupModel
    {
        public int UserId { get; set; }
        public int SectionId { get; set; }
        public int SectionNumber { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}