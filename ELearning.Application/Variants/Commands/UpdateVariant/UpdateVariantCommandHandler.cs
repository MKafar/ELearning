using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Variants.Commands.UpdateVariant
{
    public class UpdateVariantCommandHandler : IRequestHandler<UpdateVariantCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateVariantCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Variants
                .SingleAsync(e => e.VariantId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Variant), request.Id);

            entity.Content = request.Content;
            entity.Number = request.Number;
            entity.ExerciseId = request.ExerciseId;

            _context.Variants.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
