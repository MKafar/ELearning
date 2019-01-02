using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Evaluations.Commands.DeleteEvaluation
{
    public class DeleteEvaluationCommandHandler : IRequestHandler<DeleteEvaluationCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public DeleteEvaluationCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Evaluations
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            _context.Evaluations.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
