namespace ELearning.Application.Groups.Queries.GetGroupsList
{
    public class GroupLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short AcademicYear { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectAbreviation { get; set; }
    }
}
