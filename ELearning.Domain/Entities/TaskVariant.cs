using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class TaskVariant
    {
        public TaskVariant()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int TaskVariantId { get; set; }
        public string Content { get; set; }
        public string Solution { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public ICollection<Assignment> Assignments { get; private set; }
    }
}
