using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parse;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

public class LocalConnectModeHandler : ConnectModeHandler
{
    private const string Flag = "-m";
    private const string ModeIsLocal = "local";
    private const int PositionAddress = 1;
    public override void HandlerCommand(Request request)
    {
        string modeFullStringInSend = Parser.ParserFlagInRequest(request, Flag);
        if (modeFullStringInSend.Equals(ModeIsLocal, StringComparison.Ordinal))
        {
            Mode = modeFullStringInSend;
            FileCommand = new FileCommandLocal();
            FileInvoker = new FileInvoker();
            FileInvoker.SetCommand(new ConnectCommand(FileCommand, request.Arguments.ElementAtOrDefault(PositionAddress) ?? string.Empty));
            FileInvoker.ExecuteCommand();
        }
        else
        {
            NextMode?.HandlerCommand(request);
        }
    }
}