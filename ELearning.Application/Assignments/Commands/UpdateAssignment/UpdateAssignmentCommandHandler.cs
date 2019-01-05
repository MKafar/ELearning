using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateAssignmentCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .SingleAsync(e => e.AssignmentId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.Id);

            var dateOfAssignmentParseSuccessful = DateTime
                .TryParse(request.Date, new CultureInfo("pl-PL"), DateTimeStyles.AllowWhiteSpaces, out DateTime dateOfAssignment);

            if (!dateOfAssignmentParseSuccessful)
                throw new ParseDateFailureException(request.Date);

            entity.SectionId = request.SectionId;
            entity.VariantId = request.VariantId;
            entity.Date = dateOfAssignment;
            entity.FinalGrade = request.FinalGrade;

            _context.Assignments.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
