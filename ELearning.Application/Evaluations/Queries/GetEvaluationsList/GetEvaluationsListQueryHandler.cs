using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsList
{
    public class GetEvaluationsListQueryHandler : IRequestHandler<GetEvaluationsListQuery, EvaluationsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetEvaluationsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationsListViewModel> Handle(GetEvaluationsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new EvaluationsListViewModel
            {
                Evaluations = await _context.Evaluations
                    .Select(e => new EvaluationLookupModel
                    {
                        EvaluationId = e.EvaluationId,
                        AssignmentBeingEvaluatedId = e.AssignmentId,
                        SectionWhichEvaluatesId = e.SectionId,
                        Grade = e.Grade
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
