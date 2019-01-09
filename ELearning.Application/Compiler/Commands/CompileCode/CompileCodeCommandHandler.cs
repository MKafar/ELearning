﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Application.Interfaces;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Compiler.Commands.CompileCode
{
    public class CompileCodeCommandHandler : IRequestHandler<CompileCodeCommand, CompilerOutputViewModel>
    {
        private readonly ELearningDbContext _context;
        private readonly ICompilerService _compiler;
        private readonly IFileSaveService _filesave;
        private readonly DateTime _now;

        public CompileCodeCommandHandler(ELearningDbContext context, ICompilerService compiler, IFileSaveService filesave)
        {
            _context = context;
            _compiler = compiler;
            _filesave = filesave;
            _now = DateTime.Now;
        }

        public async Task<CompilerOutputViewModel> Handle(CompileCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assignments
                .FindAsync(request.AssignmentId);

            if (entity == null)
                throw new NotFoundException(nameof(Assignment), request.AssignmentId);

            var fileSettings = await _filesave.SaveToFileAsync(request.AssignmentId, request.Code, _now, cancellationToken);

            var output = await _compiler.CompileAsync(fileSettings, cancellationToken);

            return new CompilerOutputViewModel
            {
                Output = output
            };
        }
    }
}
