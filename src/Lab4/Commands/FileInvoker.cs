namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileInvoker
{
    private ICommand? _command;
    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command?.Execute();
    }
}