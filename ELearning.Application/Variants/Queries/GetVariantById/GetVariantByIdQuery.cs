using MediatR;

namespace ELearning.Application.Variants.Queries.GetVariantById
{
    public class GetVariantByIdQuery : IRequest<VariantViewModel>
    {
        public int Id { get; set; }
    }
}
