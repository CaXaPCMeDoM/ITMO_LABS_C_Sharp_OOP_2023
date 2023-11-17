using Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameFileCommand : ICommand
{
    private IFileCommand _fileCommandLocal;
    private string _path;
    private string _newName;
    public RenameFileCommand(IFileCommand fileCommandLocal, string path, string newName)
    {
        _fileCommandLocal = fileCommandLocal;
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        _fileCommandLocal.RenameFile(_path, _newName);
    }
}