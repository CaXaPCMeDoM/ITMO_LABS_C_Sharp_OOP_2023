using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

public interface IFileCommand
{
    public void Connect(string address);

    public void Disconnect();

    public void NavigateToDirectory(string path);

    public void ListDirectoryContents(int depth);

    public void ShowFile(IPrintFile printFileMode, string path);

    public void MoveFile(string sourcePath, string destinationPath);
    public void CopyFile(string sourcePath, string destinationPath);

    public void DeleteFile(string path);

    public void RenameFile(string path, string newName);
}