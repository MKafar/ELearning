using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Section
    {
        public Section()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int SectionId { get; set; }
        public int Number { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
