using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteSectionCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sections
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Section), request.Id);

            var hasAssignments = _context.Assignments
                .Any(e => e.SectionId == entity.SectionId);

            if (hasAssignments)
                throw new DeleteFailureException(nameof(Section), request.Id, "There are existing assignments associated with this section.");

            _context.Sections.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
