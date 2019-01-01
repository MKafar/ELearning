using MediatR;

namespace ELearning.Application.Variants.Commands.UpdateVariant
{
    public class UpdateVariantCommand : IRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
        public int ExerciseId { get; set; }
    }
}
