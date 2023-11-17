using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

public class ChairOfConnectMode
{
    private LocalConnectModeHandler _localConnectModeHandler = new LocalConnectModeHandler();

    public ICommand? AssemblingTheMode(Request request)
    {
        return _localConnectModeHandler.HandlerCommand(request);
    }
}