using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveFileCommand : ICommand
{
    private IFileCommand _fileCommandLocal;
    private string _sourcePath;
    private string _destinationPath;

    public MoveFileCommand(IFileCommand fileCommandLocal, string sourcePath, string destinationPath)
    {
        _fileCommandLocal = fileCommandLocal;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _fileCommandLocal.MoveFile(_sourcePath, _destinationPath);
    }
}