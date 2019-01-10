using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Assignments.Queries.GetPresentNotEvaluatedAssignmentsListById
{
    public class GetPresentNotEvaluatedAssignmentsListQueryHandler : IRequestHandler<GetPresentNotEvaluatedAssignmentsListQuery, PresentNotEvaluatedAssignmentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetPresentNotEvaluatedAssignmentsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<PresentNotEvaluatedAssignmentsListViewModel> Handle(GetPresentNotEvaluatedAssignmentsListQuery request, CancellationToken cancellationToken)
        {
            DateTime now = DateTime.Now;

            var entity = await _context.Assignments
                .SingleAsync(e => e.AssignmentId == request.Id);

            entity.Section = await _context.Sections
                .SingleAsync(e => e.SectionId == entity.SectionId);

            var evaluationsGiven = await _context.Evaluations
                .Select(e => new Evaluation
                {
                    AssignmentId = e.AssignmentId,
                    SectionId = e.SectionId
                }).Where(e => e.SectionId == entity.SectionId)
                .ToListAsync(cancellationToken);

            var vm = new PresentNotEvaluatedAssignmentsListViewModel
            {
                PresentAssignments = await _context.Assignments
                    .Select(e => new PresentNotEvaluatedAssignmentLookupModel
                    {
                        AssignmentId = e.AssignmentId,
                        Date = e.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        DateTime = e.Date,
                        Solution = e.Solution,
                        UserId = e.Section.UserId,
                        GroupId = e.Section.GroupId
                    }).Where(e => e.DateTime < now && now < e.DateTime.AddHours(1).AddMinutes(30))
                    .Where(e => !evaluationsGiven.Exists((Evaluation p) => p.AssignmentId == e.AssignmentId && p.SectionId == entity.SectionId))
                    .Where(e => e.AssignmentId != entity.AssignmentId)
                    .Where(e => e.GroupId == entity.Section.GroupId)
                    .Where(e => e.Solution != null)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
