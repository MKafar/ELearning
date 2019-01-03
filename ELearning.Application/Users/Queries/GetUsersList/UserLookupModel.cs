namespace ELearning.Application.Users.Queries.GetUsersList
{
    public class UserLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}