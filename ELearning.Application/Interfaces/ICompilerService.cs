using ELearning.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Interfaces
{
    public interface ICompilerService
    {
        Task<string> CompileAsync(IFileSettings fileSettings, CancellationToken cancellationToken);
    }
}
