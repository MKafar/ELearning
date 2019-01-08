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

            var dateTime = $"{request.Date} {request.Time}";

            var dateTimeOfAssignmentParseSuccessful = DateTime
                .TryParse(dateTime, new CultureInfo("pl-PL"), DateTimeStyles.AllowWhiteSpaces, out DateTime dateTimeOfAssignment);

            if (!dateTimeOfAssignmentParseSuccessful)
                throw new ParseDateFailureException(request.Date);

            entity.SectionId = request.SectionId;
            entity.VariantId = request.VariantId;
            entity.Date = dateTimeOfAssignment;
            entity.FinalGrade = request.FinalGrade;

            _context.Assignments.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
