using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteAssignmentCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.Id);

            var hasEvaluations = _context.Evaluations
                .Any(e => e.AssignmentId == entity.AssignmentId);

            if (hasEvaluations)
                throw new DeleteFailureException(nameof(Assignment), request.Id, "There are existing evaluations associated with this assignment.");

            _context.Assignments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
