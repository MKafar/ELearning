using ELearning.Application.Interfaces;
using ELearning.Common.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Infrastructure
{
    public class FileSaveService : IFileSaveService
    {
        public async Task<bool> SaveToFileAsync(IFileSettings fileSettings, string code, CancellationToken cancellationToken)
        {
            if (fileSettings.FilePath == null)
                throw new DirectoryNotFoundException("Path to file is not set.");

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            await File.WriteAllTextAsync(fileSettings.FilePath, code, cancellationToken);

            return Task.CompletedTask.IsCompletedSuccessfully;
        }
    }
}
