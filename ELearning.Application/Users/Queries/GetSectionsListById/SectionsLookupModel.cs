namespace ELearning.Application.Users.Queries.GetSectionsListById
{
    public class SectionsLookupModel
    {
        public int UserId { get; set; }
        public int SectionId { get; set; }
        public int SectionNumber { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}