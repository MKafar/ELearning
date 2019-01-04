using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Exercises.Queries.GetExerciseVariantsListById
{
    public class GetExerciseVariantsListByIdQueryHandler : IRequestHandler<GetExerciseVariantsListByIdQuery, VariantsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetExerciseVariantsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<VariantsListViewModel> Handle(GetExerciseVariantsListByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = new VariantsListViewModel
            {
                Variants = await _context.Variants
                    .Select(e => new VariantLookupModel
                    {
                        VariantId = e.VariantId,
                        VariantNumber = e.Number
                    }).ToListAsync(cancellationToken)
            };

            if (vm.Variants == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            return vm;
        }
    }
}
