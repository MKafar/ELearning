﻿using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public CreateAssignmentCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var dateTime = $"{request.Date} {request.Time}";

            var dateTimeOfAssignmentParseSuccessful = DateTime
                .TryParse(dateTime, new CultureInfo("pl-PL"), DateTimeStyles.AllowWhiteSpaces, out DateTime dateTimeOfAssignment);

            if (!dateTimeOfAssignmentParseSuccessful)
                throw new ParseDateFailureException(request.Date);

            var entity = new Assignment
            {
                SectionId = request.SectionId,
                VariantId = request.VariantId,
                Date = dateTimeOfAssignment
            };

            _context.Assignments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
