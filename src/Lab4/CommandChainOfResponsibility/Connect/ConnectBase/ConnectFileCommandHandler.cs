using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.ConnectBase;

public class ConnectFileCommandHandler : CommandHandlerBase
{
    private const int FirstWordIsCommand = 0;
    private const string ConnectConstString = "connect";
    protected string Mode { get; set; } = string.Empty;

    public override void HandlerCommand(Request request)
    {
        string? firstWord = request.Arguments.ElementAtOrDefault(FirstWordIsCommand);
        if (firstWord is not null
            && firstWord.Equals(ConnectConstString, StringComparison.Ordinal))
        {
            var chairOfMode = new ChairOfConnectMode();
            chairOfMode.AssemblingTheMode(request);
        }
        else
        {
            NextHandler?.HandlerCommand(request);
        }
    }
}