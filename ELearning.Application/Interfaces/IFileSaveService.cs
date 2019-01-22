using ELearning.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Interfaces
{
    public interface IFileSaveService
    {
        Task<bool> SaveToFileAsync(IFileSettings fileSettings, string code, CancellationToken cancellationToken);
    }
}
