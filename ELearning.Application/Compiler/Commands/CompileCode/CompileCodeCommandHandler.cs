using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Interfaces;
using MediatR;

namespace ELearning.Application.Compiler.Commands.CompileCode
{
    public class CompileCodeCommandHandler : IRequestHandler<CompileCodeCommand, CompilerOutputViewModel>
    {
        private readonly ICompilerService _compiler;

        public CompileCodeCommandHandler(ICompilerService compiler)
        {
            _compiler = compiler;
        }

        public async Task<CompilerOutputViewModel> Handle(CompileCodeCommand request, CancellationToken cancellationToken)
        {
            
            throw new System.NotImplementedException();
        }
    }
}
