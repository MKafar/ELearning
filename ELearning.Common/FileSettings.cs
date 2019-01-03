using System;
using System.IO;

namespace ELearning.Common
{
    public class FileSettings
    {
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

        public string FileSaveDirectory { get; set; } = null;
        public string FileName { get; set; } = null;

        public string FileNameWithoutExtension
        {
            get
            {
                if (FileName == null)
                    throw new ArgumentNullException(nameof(FileName));

                return Path.ChangeExtension(FileName, "").Substring(0, FileName.LastIndexOf('.'));
            }
        }
    }
}
