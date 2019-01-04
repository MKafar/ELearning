using ELearning.Common;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Interfaces
{
    public interface ICompilerService
    {
        Task<string> CompileAsync(string code, FileSettings fileSettings, CancellationToken cancellationToken);
    }
}
