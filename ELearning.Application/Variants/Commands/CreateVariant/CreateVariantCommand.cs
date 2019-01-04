using MediatR;

namespace ELearning.Application.Variants.Commands.CreateVariant
{
    public class CreateVariantCommand : IRequest
    {
        public int Number { get; set; }
        public int ExerciseId { get; set; }
    }
}
