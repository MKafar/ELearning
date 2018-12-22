using System;
using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AcademicYear { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Section> Sections { get; private set; }
    }
}
