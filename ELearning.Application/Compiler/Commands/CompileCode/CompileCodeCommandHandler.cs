using System;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Interfaces;
using ELearning.Common;
using MediatR;

namespace ELearning.Application.Compiler.Commands.CompileCode
{
    public class CompileCodeCommandHandler : IRequestHandler<CompileCodeCommand, CompilerOutputViewModel>
    {
        private readonly ICompilerService _compiler;
        private readonly IFileSaveService _filesave;
        private readonly DateTime _now;

        public CompileCodeCommandHandler(ICompilerService compiler, IFileSaveService filesave)
        {
            _compiler = compiler;
            _filesave = filesave;
            _now = DateTime.Now;
        }

        public async Task<CompilerOutputViewModel> Handle(CompileCodeCommand request, CancellationToken cancellationToken)
        {
            var fileSettings = await _filesave.SaveToFileAsync(request.AssignmentId, request.Code, _now, cancellationToken);

            var output = await _compiler.CompileAsync(request.Code, fileSettings, cancellationToken);

            return new CompilerOutputViewModel
            {
                Output = output
            };
        }
    }
}
