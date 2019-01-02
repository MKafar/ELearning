using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Evaluations.Models;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListBySectionId
{
    public class GetEvaluationsListBySectionIdQueryHandler : IRequestHandler<GetEvaluationsListBySectionIdQuery, EvaluationsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetEvaluationsListBySectionIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationsListViewModel> Handle(GetEvaluationsListBySectionIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Evaluations
                .Select(e => new EvaluationLookupModel
                {
                    Id = e.EvaluationId,
                    AssignmentId = e.AssignmentId,
                    SectionId = e.SectionId,
                    Grade = e.Grade
                }).Where(e => e.SectionId == request.Id)
                .ToListAsync(cancellationToken);

            if (entity == null)
                throw new NoRecordFoundException(nameof(Evaluation), nameof(Evaluation.SectionId), request.Id, "There are no evaluations associated with this section.");

            return new EvaluationsListViewModel
            {
                Evaluations = entity
            };
        }
    }
}
