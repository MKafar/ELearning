namespace ELearning.Domain.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
