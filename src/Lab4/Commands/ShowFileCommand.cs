using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowFileCommand : ICommand
{
    private IFileCommand _fileCommandLocal;
    private IPrintFile _printFile;
    private string _path;
    public ShowFileCommand(IFileCommand fileCommandLocal, IPrintFile printFile, string path)
    {
        _fileCommandLocal = fileCommandLocal;
        _path = path;
        _printFile = printFile;
    }

    public void Execute()
    {
        _fileCommandLocal.ShowFile(_printFile, _path);
    }
}