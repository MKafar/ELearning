namespace ELearning.Domain.Entities
{
    public class Role
    {
        public const string Admin = "Administrator";
        public const string Student = "Student";
        public const string AdminOrStudent = Admin + "," + Student;
    }
}
