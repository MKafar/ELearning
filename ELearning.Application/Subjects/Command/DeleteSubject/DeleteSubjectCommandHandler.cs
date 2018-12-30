using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Subjects.Command.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteSubjectCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.Id);

            var hasGroups = _context.Groups
                .Any(e => e.SubjectId == entity.SubjectId);

            if (hasGroups)
                throw new DeleteFailureException(nameof(Subject), request.Id, "There are existing groups associated with this subject.");

            _context.Subjects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
