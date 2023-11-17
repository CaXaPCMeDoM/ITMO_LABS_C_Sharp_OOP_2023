using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Disconnect;

public class DisconnectFileCommandHandler : CommandHandlerBase
{
    private const int FirstWordIsCommand = 0;
    private const string DisconnectConstString = "disconnect";

    public override void HandlerCommand(Request request)
    {
        string? firstWord = request.Arguments.ElementAtOrDefault(FirstWordIsCommand);
        if (firstWord is not null
            && firstWord.Equals(DisconnectConstString, StringComparison.Ordinal)
            && FileInvoker is not null
            && FileCommand is not null)
        {
            FileInvoker.SetCommand(new DisconnectCommand(FileCommand));
            FileInvoker.ExecuteCommand();
        }
        else
        {
            NextHandler?.HandlerCommand(request);
        }
    }
}