namespace ELearning.Application.Groups.Queries.GetGroupById
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AcademicYear { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectAbreviation { get; set; }
    }
}
