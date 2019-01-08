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
                        Solution = e.Solution,
                        FinalGrade = e.FinalGrade,
                        VariantId = e.VariantId,
                        Content = e.Variant.Content,
                        ExerciseId = e.Variant.ExerciseId,
                        ExerciseTitle = e.Variant.Exercise.Title,
                        GroupId = e.Section.GroupId,
                        GroupName = e.Section.Group.Name
                    }).Where(e => e.UserId == request.Id && DateTime.Parse(e.Date) < now)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
