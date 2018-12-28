using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Subject
    {
        public Subject()
        {
            Groups = new HashSet<Group>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; }

        public ICollection<Group> Groups { get; private set; }
    }
}
