using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Subject
    {
        public Subject()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int? MajorId { get; set; }
        public Major Major { get; set; }

        public ICollection<Group> Groups { get; private set; }
    }
}
