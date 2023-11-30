using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private IFileCommand _command;

    public DisconnectCommand(IFileCommand command)
    {
        _command = command;
    }

    public void Execute()
    {
        _command.Disconnect();
    }
}