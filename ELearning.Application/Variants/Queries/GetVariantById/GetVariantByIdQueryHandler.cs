using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Variants.Queries.GetVariantById
{
    public class GetVariantByIdQueryHandler : IRequestHandler<GetVariantByIdQuery, VariantViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetVariantByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<VariantViewModel> Handle(GetVariantByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Variants
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Variant), request.Id);

            return new VariantViewModel
            {
                Id = entity.VariantId,
                Content = entity.Content,
                Number = entity.Number,
                ExerciseId = entity.ExerciseId,
                ExerciseTitle = entity.Exercise.Title
            };
        }
    }
}
