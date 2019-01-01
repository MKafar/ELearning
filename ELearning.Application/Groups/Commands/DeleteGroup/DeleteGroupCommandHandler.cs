using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteGroupCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups
                .FindAsync(request.Id);

            var entity2 = await _context.Groups
                .SingleOrDefaultAsync(e => e.GroupId == 500);

            if (entity == null)
                throw new NotFoundException(nameof(Group), request.Id);

            var hasSections = _context.Sections.Any(e => e.GroupId == entity.GroupId);

            if (hasSections)
                throw new DeleteFailureException(nameof(Group), request.Id, "There are existing sections associated with this group.");

            _context.Groups.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
