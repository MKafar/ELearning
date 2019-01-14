using ELearning.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Interfaces
{
    public interface IFileSaveService
    {
        Task<IFileSettings> SaveToFileAsync(int assignmentId, string code, DateTime now, CancellationToken cancellationToken);
    }
}
