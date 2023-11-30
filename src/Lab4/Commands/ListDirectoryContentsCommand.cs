using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ListDirectoryContentsCommand : ICommand
{
    private IFileCommand _fileCommand;
    private int _depth;
    public ListDirectoryContentsCommand(IFileCommand fileCommand, int depth)
    {
        _fileCommand = fileCommand;
        _depth = depth;
    }

    public void Execute()
    {
        _fileCommand.ListDirectoryContents(_depth);
    }
}