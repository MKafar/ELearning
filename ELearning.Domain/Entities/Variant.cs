using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Variant
    {
        public Variant()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int VariantId { get; set; }
        public string Content { get; set; }
        public string TestingCode { get; set; }
        public string CorrectOutput { get; set; }
        public short Number { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public ICollection<Assignment> Assignments { get; private set; }
    }
}
