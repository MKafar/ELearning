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
                SectionId = entity.SectionId,
                Content = entity.Solution
            };
        }
    }
}
