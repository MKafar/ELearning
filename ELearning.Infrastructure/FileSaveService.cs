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
        private readonly IFileSettings _fileSettings;

        public FileSaveService(IFileSettings fileSettings)
        {
            _fileSettings = fileSettings;
        }

        private IFileSettings SetFileSettings(int assignmentId, DateTime now)
        {
            _fileSettings.FileName = SetFileName(assignmentId, now);
            _fileSettings.FileSaveDirectory = SetFileSaveDirectory();

            return _fileSettings;
        }

        private string SetFileName(int assignmentId, DateTime now)
        {
            var currentTime = $"{now.Hour}-{now.Minute}-{now.Second}";
            var currentDate = $"{now.Year}-{now.Month}-{now.Day}";
            var fileName = string.Format("assignmentid-{0}_{1}_{2}.cpp", assignmentId.ToString(), currentDate, currentTime);

            return fileName;
        }

        private string SetFileSaveDirectory()
        {
            var fileSaveDirectory = Directory.GetCurrentDirectory() + string.Format("{0}..{0}bin", Path.DirectorySeparatorChar);

            if (!Directory.Exists(fileSaveDirectory))
                Directory.CreateDirectory(fileSaveDirectory);

            return fileSaveDirectory;
        }

        public async Task<IFileSettings> SaveToFileAsync(int assignmentId, string code, DateTime now, CancellationToken cancellationToken)
        {
            var fileSettings = SetFileSettings(assignmentId, now);

            if (fileSettings.FilePath == null)
                throw new DirectoryNotFoundException("Path to file is not set.");

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            await File.WriteAllTextAsync(fileSettings.FilePath, code, cancellationToken);
            
            return _fileSettings;
        }
    }
}
