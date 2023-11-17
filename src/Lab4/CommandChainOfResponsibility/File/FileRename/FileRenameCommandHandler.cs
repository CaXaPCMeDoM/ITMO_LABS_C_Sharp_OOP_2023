using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileRename;

public class FileRenameCommandHandler : FileCommandHandler
{
    private const string SecondWordOfTheCommand = "rename";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionPath = 2;
    private const int PositionNewName = 3;
    public override void HandlerCommand(Request request)
    {
        string? secondWord = request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand);
        if (secondWord != null
            && secondWord.Equals(SecondWordOfTheCommand, StringComparison.Ordinal)
            && FileInvoker is not null
            && FileCommand is not null)
        {
            FileInvoker.SetCommand(
                new RenameFileCommand(
                    FileCommand,
                    request.Arguments.ElementAtOrDefault(PositionPath) ?? string.Empty,
                    request.Arguments.ElementAtOrDefault(PositionNewName) ?? string.Empty));

            FileInvoker.ExecuteCommand();
        }
        else
        {
            NextMode?.HandlerCommand(request);
        }
    }
}