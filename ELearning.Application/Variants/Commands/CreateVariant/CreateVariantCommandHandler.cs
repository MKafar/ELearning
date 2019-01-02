using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Variants.Commands.CreateVariant
{
    public class CreateVariantCommandHandler : IRequestHandler<CreateVariantCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateVariantCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = new Variant
            {
                Content = request.Content,
                Number = request.Number,
                ExerciseId = request.ExerciseId
            };

            _context.Variants.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
