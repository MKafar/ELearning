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
                        Date = e.Date.ToString(),
                        VariantId = e.VariantId,
                        VariantNumber = e.Variant.Number,
                        ExerciseId = e.Variant.ExerciseId,
                        ExerciseTitle = e.Variant.Exercise.Title,
                        SectionId = e.SectionId,
                        SectionNumber = e.Section.Number,
                        UserId = e.Section.UserId,
                        UserName = $"{e.Section.User.Name} {e.Section.User.Surname}",
                        GroupId = e.Section.GroupId,
                        GroupName = e.Section.Group.Name,
                        SubjectId = e.Section.Group.SubjectId,
                        SubjectName = e.Section.Group.Subject.Name,
                        SubjectAbreviation = e.Section.Group.Subject.Abreviation
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
