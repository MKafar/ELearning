using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Subjects.Command.UpdateSubject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateSubjectCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects
                .SingleOrDefaultAsync(e => e.SubjectId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.Id);

            entity.Name = request.Name;
            entity.Abreviation = request.Abreviation;

            _context.Subjects.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
