using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Compiler.Commands.SaveAssignmentSolution
{
    public class SaveAssignmentSolutionCommandHandler : IRequestHandler<SaveAssignmentSolutionCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public SaveAssignmentSolutionCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SaveAssignmentSolutionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .SingleAsync(e => e.AssignmentId == request.AssignmentId);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.AssignmentId);

            entity.Solution = request.Solution;

            _context.Assignments.Update(entity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
