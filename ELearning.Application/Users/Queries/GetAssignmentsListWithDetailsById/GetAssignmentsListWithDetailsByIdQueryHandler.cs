using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById
{
    public class GetAssignmentsListWithDetailsByIdQueryHandler : IRequestHandler<GetAssignmentsListWithDetailsByIdQuery, AssignmentsListWithDetailsViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetAssignmentsListWithDetailsByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentsListWithDetailsViewModel> Handle(GetAssignmentsListWithDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            var vm = new AssignmentsListWithDetailsViewModel
            {
                UserAssignmentsWithDetails = await _context.Assignments
                    .Select(e => new AssignmentWithDetailsLookupModel
                    {
                        UserId = e.Section.UserId,
                        AssignmentId = e.AssignmentId,
                        AssignmentDate = e.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        AssignmentTime = e.Date.ToString("hh:MM", CultureInfo.InvariantCulture),
                        AssignmentFinalGrade = e.FinalGrade,
                        VariantId = e.VariantId,
                        VariantNumber = e.Variant.Number,
                        ExerciseTitle = e.Variant.Exercise.Title,
                        SectionId = e.SectionId,
                        GroupName = e.Section.Group.Name
                    }).Where(e => e.UserId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
