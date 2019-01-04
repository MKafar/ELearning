using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Sections.Queries.GetSectionEvaluationsListById
{
    public class GetSectionEvaluationsListByIdQueryHandler : IRequestHandler<GetSectionEvaluationsListByIdQuery, SectionEvaluationsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSectionEvaluationsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SectionEvaluationsListViewModel> Handle(GetSectionEvaluationsListByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = new SectionEvaluationsListViewModel
            {
                SectionEvaluations = await _context.Evaluations
                    .Select(e => new SectionEvaluationLookupModel
                    {
                        SectionWhichEvaluatesId = e.SectionId,
                        AssignmentBeingEvaluatedId = e.AssignmentId,
                        EvaluationId = e.EvaluationId,
                        Grade = e.Grade
                    }).Where(e => e.SectionWhichEvaluatesId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            if (vm == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            return vm;
        }
    }
}
