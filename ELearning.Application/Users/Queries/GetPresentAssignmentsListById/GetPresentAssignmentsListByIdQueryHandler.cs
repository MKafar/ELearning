using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetPresentAssignmentsListById
{
    public class GetPresentAssignmentsListByIdQueryHandler : IRequestHandler<GetPresentAssignmentsListByIdQuery, PresentAssignmentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetPresentAssignmentsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<PresentAssignmentsListViewModel> Handle(GetPresentAssignmentsListByIdQuery request, CancellationToken cancellationToken)
        {
            DateTime now = DateTime.Now;

            // TODO sprawdzić porównanie dat - być może nie działa prawidłowo

            var vm = new PresentAssignmentsListViewModel
            {
                PresentAssignments = await _context.Assignments
                    .Select(e => new PresentAssignmentLookupModel
                    {
                        AssignmentId = e.AssignmentId,
                        Date = e.Date.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Time = e.Date.TimeOfDay.ToString("HH:mm", CultureInfo.InvariantCulture),
                        VariantId = e.VariantId,
                        Content = e.Variant.Content,
                        ExerciseId = e.Variant.ExerciseId,
                        ExerciseTitle = e.Variant.Exercise.Title,
                        GroupId = e.Section.GroupId,
                        GroupName = e.Section.Group.Name,
                        UserId = e.Section.UserId
                    }).Where(e => e.UserId == request.Id)
                    .Where(e => DateTime.Parse(e.Date) < now && now < DateTime.Parse(e.Date).AddHours(1).AddMinutes(30))
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
