using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Variants.Commands.DeleteVariant
{
    public class DeleteVariantCommandHandler : IRequestHandler<DeleteVariantCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteVariantCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Variants
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Variant), request.Id);

            var hasAssignments = _context.Assignments
                .Any(e => e.VariantId == entity.VariantId);

            if (hasAssignments)
                throw new DeleteFailureException(nameof(Variant), request.Id, "There are existing assignments associated with this variant.");

            _context.Variants.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
