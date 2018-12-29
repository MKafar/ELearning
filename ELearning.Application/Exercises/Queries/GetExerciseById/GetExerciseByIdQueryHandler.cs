using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var vm = await _context.Exercises
                .Select(c => new ExerciseViewModel
                {
                    Id = c.ExerciseId,
                    Title = c.Title,
                    
                }).Where(r => r.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return vm;
        }
    }
}
