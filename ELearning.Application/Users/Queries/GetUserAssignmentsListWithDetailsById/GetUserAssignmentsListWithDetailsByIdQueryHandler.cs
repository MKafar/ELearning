using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById
{
    public class GetUserAssignmentsListWithDetailsByIdQueryHandler : IRequestHandler<GetUserAssignmentsListWithDetailsByIdQuery, UserAssignmentsListWithDetailsViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetUserAssignmentsListWithDetailsByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<UserAssignmentsListWithDetailsViewModel> Handle(GetUserAssignmentsListWithDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = new UserAssignmentsListWithDetailsViewModel
            {
                AssignmentsWithDetails = await _context.Assignments
                    .Select(e => new UserAssignmentWithDetailsLookupModel
                    {
                        UserId = e.Section.UserId,
                        AssignmentId = e.AssignmentId,
                        AssignmentDate = e.Date.ToString(),
                        AssignmentFinalGrade = e.FinalGrade,
                        VariantId = e.VariantId,
                        VariantNumber = e.Variant.Number,
                        ExerciseTitle = e.Variant.Exercise.Title,
                        SectionId = e.SectionId,
                        GroupName = e.Section.Group.Name
                    }).Where(e => e.UserId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            if (vm == null)
                throw new NotFoundException(nameof(User), request.Id);

            return vm;
        }
    }
}
