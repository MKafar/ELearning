using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Sections = new HashSet<Section>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public int AcademicYear { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Section> Sections { get; private set; }
    }
}
