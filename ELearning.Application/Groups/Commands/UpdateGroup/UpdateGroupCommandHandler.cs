using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateGroupCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups
                .SingleAsync(e => e.GroupId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Group), request.Id);

            entity.Name = request.Name;
            entity.AcademicYear = request.AcademicYear;
            entity.SubjectId = request.SubjectId;

            _context.Groups.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
