using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteFileCommand : ICommand
{
    private IFileCommand _fileCommandLocal;
    private string _path;

    public DeleteFileCommand(IFileCommand fileCommandLocal, string path)
    {
        _fileCommandLocal = fileCommandLocal;
        _path = path;
    }

    public void Execute()
    {
        _fileCommandLocal.DeleteFile(_path);
    }
}