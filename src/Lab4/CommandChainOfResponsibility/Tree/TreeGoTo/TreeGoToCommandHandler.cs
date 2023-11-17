using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeGoTo;

public class TreeGoToCommandHandler : TreeFileCommandHandler
{
    private const string SecondWordOfTheCommand = "goto";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionPath = 2;
    public override ICommand? HandlerCommand(Request request)
    {
        if (request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand) == SecondWordOfTheCommand
            && FileInvoker is not null
            && FileCommand is not null)
        {
            var navigateToDirectoryCommand = new NavigateToDirectoryCommand(
                FileCommand,
                request.Arguments.ElementAtOrDefault(PositionPath) ?? string.Empty);
            FileInvoker.SetCommand(navigateToDirectoryCommand);

            FileInvoker.ExecuteCommand();
            return navigateToDirectoryCommand;
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