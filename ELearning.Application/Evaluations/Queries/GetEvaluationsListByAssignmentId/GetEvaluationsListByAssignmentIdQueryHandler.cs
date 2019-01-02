using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Evaluations.Models;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationsListByAssignmentId
{
    public class GetEvaluationsListByAssignmentIdQueryHandler : IRequestHandler<GetEvaluationsListByAssignmentIdQuery, EvaluationsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetEvaluationsListByAssignmentIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationsListViewModel> Handle(GetEvaluationsListByAssignmentIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Evaluations
                .Select(e => new EvaluationLookupModel
                {
                    Id = e.EvaluationId,
                    AssignmentId = e.AssignmentId,
                    SectionId = e.SectionId,
                    Grade = e.Grade
                }).Where(e => e.AssignmentId == request.Id)
                .ToListAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            return new EvaluationsListViewModel
            {
                Evaluations = entity
            };
        }
    }
}
