using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.ConnectBase;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

public abstract class ConnectModeHandler : ConnectFileCommandHandler
{
    protected ConnectModeHandler? NextMode { get; private set; }

    public ConnectModeHandler SetNextMode(ConnectModeHandler connectModeHandler)
    {
        if (NextMode is null)
        {
            NextMode = connectModeHandler;
        }
        else
        {
            NextMode.SetNextHandler(connectModeHandler);
        }

        return this;
    }
}