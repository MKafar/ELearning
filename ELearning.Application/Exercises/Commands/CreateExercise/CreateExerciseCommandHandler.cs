using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using ELearning.Domain.Entities;

namespace ELearning.Application.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateExerciseCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Exercise
            {
                Title = request.Title
            };

            _context.Exercises.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
