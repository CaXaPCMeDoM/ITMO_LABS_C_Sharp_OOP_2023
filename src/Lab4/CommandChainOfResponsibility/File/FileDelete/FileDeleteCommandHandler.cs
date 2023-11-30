using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileDelete;

public class FileDeleteCommandHandler : FileCommandHandler
{
    private const string SecondWordOfTheCommand = "delete";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionPath = 2;
    public override ICommand? HandlerCommand(Request request)
    {
        string? secondWord = request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand);
        if (secondWord != null
            && secondWord.Equals(SecondWordOfTheCommand, StringComparison.Ordinal)
            && FileInvoker is not null
            && FileCommand is not null)
        {
            var deleteFileCommand = new DeleteFileCommand(
                FileCommand,
                request.Arguments.ElementAtOrDefault(PositionPath) ?? string.Empty);
            FileInvoker.SetCommand(deleteFileCommand);

            FileInvoker.ExecuteCommand();

            return deleteFileCommand;
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