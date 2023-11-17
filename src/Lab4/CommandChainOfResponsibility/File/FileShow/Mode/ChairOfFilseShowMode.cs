namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;

public class ChairOfFilseShowMode
{
    private FileShowConsoleMode _fileShowConsole = new FileShowConsoleMode();

    public void AssemblingTheMode(Request request)
    {
        _fileShowConsole.HandlerCommand(request);
    }
}