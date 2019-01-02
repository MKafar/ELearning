using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateSectionCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sections
                .SingleAsync(e => e.SectionId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Section), request.Id);

            entity.GroupId = request.GroupId;
            entity.UserId = request.UserId;
            entity.Number = request.Number;

            _context.Sections.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
