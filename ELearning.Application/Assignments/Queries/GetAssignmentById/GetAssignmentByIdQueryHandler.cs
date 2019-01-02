using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQueryHandler : IRequestHandler<GetAssignmentByIdQuery, AssignmentViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetAssignmentByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentViewModel> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.Id);

            return new AssignmentViewModel
            {
                Id = entity.AssignmentId,
                Date = entity.Date.ToString(),
                VariantId = entity.VariantId,
                VariantNumber = entity.Variant.Number,
                ExerciseId = entity.Variant.ExerciseId,
                ExerciseTitle = entity.Variant.Exercise.Title,
                SectionId = entity.SectionId,
                SectionNumber = entity.Section.Number,
                UserId = entity.Section.UserId,
                UserName = $"{entity.Section.User.Name} {entity.Section.User.Surname}",
                GroupId = entity.Section.GroupId,
                GroupName = entity.Section.Group.Name,
                SubjectId = entity.Section.Group.SubjectId,
                SubjectName = entity.Section.Group.Subject.Name,
                SubjectAbreviation = entity.Section.Group.Subject.Abreviation
            };
        }
    }
}
