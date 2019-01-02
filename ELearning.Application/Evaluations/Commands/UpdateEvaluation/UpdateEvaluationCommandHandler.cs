using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Evaluations.Commands.UpdateEvaluation
{
    public class UpdateEvaluationCommandHandler : IRequestHandler<UpdateEvaluationCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateEvaluationCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Evaluations
                .SingleAsync(e => e.EvaluationId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            entity.AssignmentId = request.AssignmentId;
            entity.SectionId = request.SectionId;
            entity.Grade = request.Grade;

            _context.Evaluations.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
