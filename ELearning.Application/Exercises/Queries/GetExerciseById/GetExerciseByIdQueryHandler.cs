using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetExerciseByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<ExerciseViewModel> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Exercises
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            return new ExerciseViewModel
            {
                Id = entity.ExerciseId,
                Title = entity.Title            
            };
        }
    }
}
