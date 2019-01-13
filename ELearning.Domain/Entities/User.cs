using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class User
    {
        public User()
        {
            Sections = new HashSet<Section>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public ICollection<Section> Sections { get; private set; }
    }
}
