using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class NavigateToDirectoryCommand : ICommand
{
    private IFileCommand _command;
    private string _path;

    public NavigateToDirectoryCommand(IFileCommand command, string path)
    {
        _command = command;
        _path = path;
    }

    public void Execute()
    {
        _command.NavigateToDirectory(_path);
    }
}