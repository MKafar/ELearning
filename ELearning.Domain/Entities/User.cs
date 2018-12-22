using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public enum Role
    {
        Student,
        Administrator
    }

    public class User
    {
        public User()
        {
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public ICollection<Section> Sections { get; private set; }
    }
}
