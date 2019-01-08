using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetUserPastAssignmentsListById
{
    public class GetUserPastAssignmentsListByIdQueryHandler : IRequestHandler<GetUserPastAssignmentsListByIdQuery, UserPastAssignmentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetUserPastAssignmentsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<UserPastAssignmentsListViewModel> Handle(GetUserPastAssignmentsListByIdQuery request, CancellationToken cancellationToken)
        {
            DateTime now = DateTime.Now;

            var vm = new UserPastAssignmentsListViewModel
            {
                PastAssignments = await _context.Assignments
                    .Select(e => new UserPastAssignmentLookupModel
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
