using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;
using Itmo.ObjectOrientedProgramming.Lab4.Parse;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;

public class FileShowConsoleMode : FileShowModeHandler
{
    private const string Flag = "-m";
    private const string ConsoleMode = "console";
    private const int PositionOfAddress = 2;
    public override Commands.ICommand? HandlerCommand(Request request)
    {
        string modeFullStringInSend = Parser.ParserFlagInRequest(request, Flag);
        if (modeFullStringInSend == ConsoleMode
            && FileCommand is not null
            && FileInvoker is not null)
        {
            IPrintFile printFile = new PrintFileToConsole();
            var showFileCommand = new ShowFileCommand(
                FileCommand,
                printFile,
                request.Arguments.ElementAtOrDefault(PositionOfAddress) ?? string.Empty);
            FileInvoker.SetCommand(showFileCommand);

            FileInvoker.ExecuteCommand();

            return showFileCommand;
        }
        else
        {
            NextMode?.HandlerCommand(request);
            return null;
        }
    }
}