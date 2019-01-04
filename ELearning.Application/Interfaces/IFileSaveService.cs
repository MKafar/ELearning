using ELearning.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Interfaces
{
    public interface IFileSaveService
    {
        Task<FileSettings> SaveToFileAsync(int assignmentId, string code, DateTime now, CancellationToken cancellationToken);
    }
}
