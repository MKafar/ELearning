using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand>
    {
        private readonly ELearningDbContext _context;

        public DeleteExerciseCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Exercises
                .FindAsync(request.Id);

            if(entity == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            var hasVariants = _context.Variants.Any(e => e.ExerciseId == entity.ExerciseId);
            if(hasVariants)
                throw new DeleteFailureException(nameof(Exercise), request.Id, "There are existing variants associated with this exercise.");

            _context.Exercises.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
