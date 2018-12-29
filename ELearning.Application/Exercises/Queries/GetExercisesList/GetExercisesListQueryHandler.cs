using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Exercises.Queries.GetExercisesList
{
    public class GetExercisesListQueryHandler : IRequestHandler<GetExercisesListQuery, ExercisesListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetExercisesListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<ExercisesListViewModel> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExercisesListViewModel
            {
                Exercises = await _context.Exercises.Select(c => 
                    new ExerciseLookupModel
                    {
                        Id = c.ExerciseId,
                        Title = c.Title
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
