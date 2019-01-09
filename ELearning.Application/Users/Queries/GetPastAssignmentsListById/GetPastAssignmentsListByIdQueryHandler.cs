using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetPastAssignmentsListById
{
    public class GetPastAssignmentsListByIdQueryHandler : IRequestHandler<GetPastAssignmentsListByIdQuery, PastAssignmentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetPastAssignmentsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<PastAssignmentsListViewModel> Handle(GetPastAssignmentsListByIdQuery request, CancellationToken cancellationToken)
        {
            DateTime now = DateTime.Now;

            var vm = new PastAssignmentsListViewModel
            {
                PastAssignments = await _context.Assignments
                    .Select(e => new PastAssignmentLookupModel
                    {
                        AssignmentId = e.AssignmentId,
                        UserId = e.Section.UserId,
                        Date = e.Date.ToString("dd-MM-yyyy"),
                        ExerciseTitle = e.Variant.Exercise.Title,
                        GroupName = e.Section.Group.Name
                    }).Where(e => e.UserId == request.Id && DateTime.Parse(e.Date) < now)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
