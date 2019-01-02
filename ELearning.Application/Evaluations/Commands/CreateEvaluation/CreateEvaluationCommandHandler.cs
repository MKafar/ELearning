using System.Threading;
using System.Threading.Tasks;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Evaluations.Commands.CreateEvaluation
{
    public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateEvaluationCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Evaluation
            {
                AssignmentId = request.AssignmentId,
                SectionId = request.SectionId,
                Grade = request.Grade
            };

            _context.Evaluations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
