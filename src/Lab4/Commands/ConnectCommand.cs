using Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private IFileCommand _command;
    private string _address;

    public ConnectCommand(IFileCommand command, string address)
    {
        _command = command;
        _address = address;
    }

    public void Execute()
    {
        _command.Connect(_address);
    }
}