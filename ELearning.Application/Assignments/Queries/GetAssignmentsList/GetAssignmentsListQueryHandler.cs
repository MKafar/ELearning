using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Assignments.Queries.GetAssignmentsList
{
    public class GetAssignmentsListQueryHandler : IRequestHandler<GetAssignmentsListQuery, AssignmentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetAssignmentsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentsListViewModel> Handle(GetAssignmentsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new AssignmentsListViewModel
            {
                Assignments = await _context.Assignments
                    .Select(e => new AssignmentLookupModel
                    {
                        Id = e.AssignmentId,
                        Date = e.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        VariantId = e.VariantId,
                        SectionId = e.SectionId
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
