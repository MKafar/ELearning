using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Subjects.Command.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateSubjectCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Subject
            {
                Name = request.Name,
                Abreviation = request.Abreviation
            };

            _context.Subjects.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
