using MediatR;

namespace ELearning.Application.Variants.Commands.DeleteVariant
{
    public class DeleteVariantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
