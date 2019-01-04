using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Variants.Commands.CreateVariant
{
    public class CreateVariantCommandHandler : IRequestHandler<CreateVariantCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateVariantCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = new Variant
            {
                Number = request.Number,
                ExerciseId = request.ExerciseId,
                Content = request.Content != null ? request.Content : "No content"
            };

            var variantAlreadyExists = _context.Variants
                .Any(e => e.ExerciseId == entity.ExerciseId && e.Number == entity.Number);

            if (variantAlreadyExists)
                throw new NotUniqueException(nameof(Variant), nameof(Variant.ExerciseId), request.ExerciseId, nameof(Variant.Number), request.Number);

            _context.Variants.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
