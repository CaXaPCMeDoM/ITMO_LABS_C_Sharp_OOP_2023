using Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CopyFileCommand : ICommand
{
    private IFileCommand _fileCommandLocal;
    private string _sourcePath;
    private string _destinationPath;

    public CopyFileCommand(IFileCommand fileCommandLocal, string sourcePath, string destinationPath)
    {
        _fileCommandLocal = fileCommandLocal;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _fileCommandLocal.CopyFile(_sourcePath, _destinationPath);
    }
}