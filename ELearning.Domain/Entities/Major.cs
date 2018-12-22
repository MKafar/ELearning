using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Major
    {
        public Major()
        {
            Subjects = new HashSet<Subject>();
        }

        public int MajorId { get; set; }
        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; private set; }
    }
}
