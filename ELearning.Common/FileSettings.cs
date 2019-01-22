using ELearning.Common.Interfaces;
using System;
using System.IO;

namespace ELearning.Common
{
    public class FileSettings : IFileSettings
    {
        private readonly int _assignmentId;
        private readonly DateTime _now;

        public FileSettings(int assignmentId, DateTime now)
        {
            _assignmentId = assignmentId;
            _now = now;
        }

        public string FileName
        {
            get
            {
                var currentTime = $"{_now.Hour}-{_now.Minute}-{_now.Second}";
                var currentDate = $"{_now.Year}-{_now.Month}-{_now.Day}";
                var fileName = string.Format("assignmentid-{0}_{1}_{2}.cpp", _assignmentId.ToString(), currentDate, currentTime);

                return fileName;
            }
        }

        public string FileSaveDirectory
        {
            get
            {
                var fileSaveDirectory = Directory.GetCurrentDirectory() + string.Format("{0}..{0}bin", Path.DirectorySeparatorChar);

                if (!Directory.Exists(fileSaveDirectory))
                    Directory.CreateDirectory(fileSaveDirectory);

                return fileSaveDirectory;
            }
        }

        public string FilePath
        {
            get
            {
                if (FileSaveDirectory == null)
                    throw new ArgumentNullException(nameof(FileSaveDirectory));

                if (FileName == null)
                    throw new ArgumentNullException(nameof(FileName));

                return string.Format("{0}{1}{2}",
                    FileSaveDirectory, 
                    Path.DirectorySeparatorChar, 
                    FileName);
            }
        }

        public string CompiledFilePath
        {
            get
            {
                if (FileSaveDirectory == null)
                    throw new ArgumentNullException(nameof(FileSaveDirectory));

                if (FileNameWithExeExtension == null)
                    throw new ArgumentNullException(nameof(FileNameWithExeExtension));

                return string.Format("{0}{1}{2}",
                    FileSaveDirectory,
                    Path.DirectorySeparatorChar,
                    FileNameWithExeExtension);
            }
        }

        public string FileNameWithExeExtension
        {
            get
            {
                if (FileName == null)
                    throw new ArgumentNullException(nameof(FileName));

                return Path.ChangeExtension(FileName, "exe");
            }
        }
    }
}
