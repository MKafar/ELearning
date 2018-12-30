using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateExerciseCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Exercises
                .SingleAsync(c => c.ExerciseId == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            entity.Title = request.Title;

            _context.Exercises.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
