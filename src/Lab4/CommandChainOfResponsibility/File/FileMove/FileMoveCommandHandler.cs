using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileMove;

public class FileMoveCommandHandler : FileCommandHandler
{
    private const string SecondWordOfTheCommand = "move";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionSourcePath = 2;
    private const int PositionDestinationPath = 3;
    public override ICommand? HandlerCommand(Request request)
    {
        string? firstWord = request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand);
        if (firstWord != null
            && firstWord.Equals(SecondWordOfTheCommand, StringComparison.Ordinal)
            && FileInvoker is not null
            && FileCommand is not null)
        {
            var moveFileCommand = new MoveFileCommand(
                FileCommand,
                request.Arguments.ElementAtOrDefault(PositionSourcePath) ?? string.Empty,
                request.Arguments.ElementAtOrDefault(PositionDestinationPath) ?? string.Empty);

            FileInvoker.SetCommand(moveFileCommand);

            FileInvoker.ExecuteCommand();
            return moveFileCommand;
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