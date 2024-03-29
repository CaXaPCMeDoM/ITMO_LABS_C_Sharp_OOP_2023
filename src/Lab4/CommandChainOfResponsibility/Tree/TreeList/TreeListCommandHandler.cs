using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeList;

public class TreeListCommandHandler : TreeFileCommandHandler
{
    private const string SecondWordOfTheCommand = "list";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionDepth = 3;

    public override ICommand? HandlerCommand(Request request)
    {
        int depthValue;
        if (request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand) == SecondWordOfTheCommand
            && FileInvoker is not null
            && FileCommand is not null)
        {
            if (int.TryParse(request.Arguments.ElementAtOrDefault(PositionDepth), out depthValue))
            {
                var listDirectoryContentsCommand = new ListDirectoryContentsCommand(
                    FileCommand,
                    depthValue);

                FileInvoker.SetCommand(listDirectoryContentsCommand);

                FileInvoker.ExecuteCommand();

                return listDirectoryContentsCommand;
            }
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

        return null;
    }
}