using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;

public class ChairOfFilseShowMode
{
    private FileShowConsoleMode _fileShowConsole = new FileShowConsoleMode();

    public ICommand? AssemblingTheMode(Request request)
    {
        return _fileShowConsole.HandlerCommand(request);
    }
}