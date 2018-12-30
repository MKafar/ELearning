using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ELearningDbContext _context;

        public DeleteUserCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            var hasSections = _context.Sections
                .Any(e => e.UserId == entity.UserId);

            if (hasSections)
                throw new DeleteFailureException(nameof(User), request.Id, "There are existing sections associated with this user.");

            _context.Users.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
