namespace ELearning.Common.Interfaces
{
    public interface IFileSettings
    {
        string FileName { get; }
        string FileSaveDirectory { get; }
        string FilePath { get; }
        string CompiledFilePath { get; }
        string FileNameWithExeExtension { get; }
    }
}
