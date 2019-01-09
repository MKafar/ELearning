﻿using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQueryHandler : IRequestHandler<GetAssignmentByIdQuery, AssignmentViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetAssignmentByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentViewModel> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .SingleAsync(e => e.AssignmentId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.Id);

            entity.Variant = await _context.Variants
                .SingleAsync(e => e.VariantId == entity.VariantId);

            entity.Variant.Exercise = await _context.Exercises
                .SingleAsync(e => e.ExerciseId == entity.Variant.ExerciseId);

            string parsedDate = entity.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string parsedTime = entity.Date.ToString("HH:mm", CultureInfo.InvariantCulture);

            return new AssignmentViewModel
            {
                Id = entity.AssignmentId,
                SectionId = entity.SectionId,
                Date = parsedDate,
                Time = parsedTime,
                Solution = entity.Solution,
                FinalGrade = entity.FinalGrade,
                
                VariantId = entity.VariantId,
                Content = entity.Variant.Content,

                ExerciseTitle = entity.Variant.Exercise.Title
            };
        }
    }
}
