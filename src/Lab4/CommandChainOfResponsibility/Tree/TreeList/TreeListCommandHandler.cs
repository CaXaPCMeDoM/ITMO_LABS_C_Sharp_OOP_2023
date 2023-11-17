using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeList;

public class TreeListCommandHandler : TreeFileCommandHandler
{
    private const string SecondWordOfTheCommand = "list";
    private const int PositionSecondWordOfTheCommand = 1;
    private const int PositionDepth = 3;

    public override void HandlerCommand(Request request)
    {
        int depthValue;
        if (int.TryParse(request.Arguments.ElementAtOrDefault(PositionDepth), out depthValue))
        {
            if (request.Arguments.ElementAtOrDefault(PositionSecondWordOfTheCommand) == SecondWordOfTheCommand
                && FileInvoker is not null
                && FileCommand is not null)
            {
                FileInvoker.SetCommand(
                    new ListDirectoryContentsCommand(
                        FileCommand,
                        depthValue));

                FileInvoker.ExecuteCommand();
            }
            else
            {
                NextMode?.HandlerCommand(request);
            }
        }
    }
}