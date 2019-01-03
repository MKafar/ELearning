using MediatR;

namespace ELearning.Application.Compiler.Commands.CompileCode
{
    public class CompileCodeCommand : IRequest<CompilerOutputViewModel>
    {
        public int AssignmentId { get; set; }
        public string Code { get; set; }
    }
}
