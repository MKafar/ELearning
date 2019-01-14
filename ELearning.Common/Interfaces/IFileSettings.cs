namespace ELearning.Common.Interfaces
{
    public interface IFileSettings
    {
        string FilePath { get; }
        string CompiledFilePath { get; }
        string FileSaveDirectory { get; set; }
        string FileName { get; set; }
        string FileNameWithExeExtension { get; }
    }
}
