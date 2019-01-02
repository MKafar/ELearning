namespace ELearning.Application.Variants.Queries.GetVariantsList
{
    public class VariantLookupModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseTitle { get; set; }
    }
}
