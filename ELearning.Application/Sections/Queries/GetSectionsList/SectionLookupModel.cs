namespace ELearning.Application.Sections.Queries.GetSectionsList
{
    public class SectionLookupModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Number { get; set; }
    }
}
