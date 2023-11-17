namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

public class ChairOfConnectMode
{
    private LocalConnectModeHandler _localConnectModeHandler = new LocalConnectModeHandler();

    public void AssemblingTheMode(Request request)
    {
        _localConnectModeHandler.HandlerCommand(request);
    }
}