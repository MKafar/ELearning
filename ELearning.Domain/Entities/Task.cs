using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Task
    {
        public Task()
        {
            TaskVariants = new HashSet<TaskVariant>();
        }

        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<TaskVariant> TaskVariants { get; private set; }
    }
}
