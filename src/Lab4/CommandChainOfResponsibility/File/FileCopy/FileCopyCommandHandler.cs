using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileCopy;

public class FileCopyCommandHandler : FileCommandHandler
{
    private const string SecondWordOfTheCommand = "copy";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionSourcePath = 2;
    private const int PositionDestinationPath = 3;
    public override void HandlerCommand(Request request)
    {
        string? secondWord = request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand);
        if (secondWord != null
            && secondWord.Equals(SecondWordOfTheCommand, StringComparison.Ordinal)
            && FileInvoker is not null
            && FileCommand is not null)
        {
            FileInvoker.SetCommand(
                new CopyFileCommand(
                    FileCommand,
                    request.Arguments.ElementAtOrDefault(PositionSourcePath) ?? string.Empty,
                    request.Arguments.ElementAtOrDefault(PositionDestinationPath) ?? string.Empty));

            FileInvoker.ExecuteCommand();
        }
        else
        {
            NextMode?.HandlerCommand(request);
        }
    }
}