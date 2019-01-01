using MediatR;

namespace ELearning.Application.Variants.Commands.CreateVariant
{
    public class CreateVariantCommand : IRequest
    {
        public string Content { get; set; }
        public int Number { get; set; }
        public int ExerciseId { get; set; }
    }
}
