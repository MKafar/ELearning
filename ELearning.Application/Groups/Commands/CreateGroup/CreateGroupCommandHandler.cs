using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateGroupCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                Name = request.Name,
                AcademicYear = request.AcademicYear,
                SubjectId = request.SubjectId
            };

            _context.Groups.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
