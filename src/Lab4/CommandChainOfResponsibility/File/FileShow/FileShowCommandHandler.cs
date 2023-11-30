using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow;

public class FileShowCommandHandler : FileCommandHandler
{
    private const string SecondWordOfTheCommand = "show";
    private const int PositionSecondWordOfTheCommand = 1;
    public override ICommand? HandlerCommand(Request request)
    {
        string? secondWord = request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand);
        if (secondWord != null
            && secondWord.Equals(SecondWordOfTheCommand, StringComparison.Ordinal))
        {
            var chairShowMode = new ChairOfFilseShowMode();
            return chairShowMode.AssemblingTheMode(request);
        }
        else
        {
            NextMode?.HandlerCommand(request);
            return null;
        }
    }
}