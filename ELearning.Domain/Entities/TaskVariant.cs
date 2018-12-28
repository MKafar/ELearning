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
        public string TestingCode { get; set; }
        public string CorrectOutput { get; set; }
        public short Number { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public ICollection<Assignment> Assignments { get; private set; }
    }
}
