namespace ELearning.Application.Groups.Queries.GetGroupSectionsListById
{
    public class GroupSectionLookupModel
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int SectionId { get; set; }
        public int SectionNumber { get; set; }
    }
}
