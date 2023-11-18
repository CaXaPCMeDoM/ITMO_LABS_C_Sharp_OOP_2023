using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parse;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.Mode;

public class LocalConnectModeHandler : ConnectModeHandler
{
    private const string Flag = "-m";
    private const string ModeIsLocal = "local";
    private const int PositionAddress = 1;
    public override ICommand? HandlerCommand(Request request)
    {
        string modeFullStringInSend = Parser.ParserFlagInRequest(request, Flag);
        if (modeFullStringInSend.Equals(ModeIsLocal, StringComparison.Ordinal))
        {
            Mode = modeFullStringInSend;
            FileCommand = new FileCommandLocal();
            FileInvoker = new FileInvoker();
            var connectCommand = new ConnectCommand(
                FileCommand,
                request.Arguments.ElementAtOrDefault(PositionAddress) ?? string.Empty);

            FileInvoker.SetCommand(connectCommand);
            FileInvoker.ExecuteCommand();
            return connectCommand;
        }
        else
        {
            if (NextMode is not null)
            {
                return NextMode.HandlerCommand(request);
            }
            else
            {
                return null;
            }
        }
    }
}