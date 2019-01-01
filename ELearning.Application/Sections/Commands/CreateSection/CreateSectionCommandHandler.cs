using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Sections.Commands.CreateSection
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateSectionCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Section
            {
                GroupId = request.GroupId,
                UserId = request.UserId,
                Number = request.Number
            };

            _context.Sections.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
