using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeGoTo;

public class TreeGoToCommandHandler : TreeFileCommandHandler
{
    private const string SecondWordOfTheCommand = "goto";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionPath = 2;
    public override void HandlerCommand(Request request)
    {
        if (request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand) == SecondWordOfTheCommand
            && FileInvoker is not null
            && FileCommand is not null)
        {
            FileInvoker.SetCommand(
                new NavigateToDirectoryCommand(
                    FileCommand,
                    request.Arguments.ElementAtOrDefault(PositionPath) ?? string.Empty));

            FileInvoker.ExecuteCommand();
        }
        else
        {
            NextMode?.HandlerCommand(request);
        }
    }
}