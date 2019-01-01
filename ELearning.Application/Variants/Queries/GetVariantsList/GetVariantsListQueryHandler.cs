using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Variants.Queries.GetVariantsList
{
    public class GetVariantsListQueryHandler : IRequestHandler<GetVariantsListQuery, VariantsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetVariantsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<VariantsListViewModel> Handle(GetVariantsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new VariantsListViewModel
            {
                Variants = await _context.Variants
                    .Select(e => new VariantLookupModel
                    {
                        Id = e.VariantId,
                        Content = e.Content,
                        Number = e.Number,
                        ExerciseId = e.ExerciseId,
                        ExerciseTitle = e.Exercise.Title
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
