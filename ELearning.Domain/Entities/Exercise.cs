using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Exercise
    {
        public Exercise()
        {
            Variants = new HashSet<Variant>();
        }

        public int ExerciseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Variant> Variants { get; private set; }
    }
}
