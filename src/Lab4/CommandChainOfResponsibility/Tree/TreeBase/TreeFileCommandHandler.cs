using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;

public class TreeFileCommandHandler : CommandHandlerBase
{
    private const int FirstWord = 0;
    private const string FileConstString = "tree";
    protected TreeFileCommandHandler? NextMode { get; private set; }
    public void SetNextMode(TreeFileCommandHandler modeHandler)
    {
        NextMode = modeHandler;
    }

    public override ICommand? HandlerCommand(Request request)
    {
        if (request.Arguments.ElementAtOrDefault(FirstWord) == FileConstString)
        {
            var chairmode = new ChairOfTree();
            return chairmode.AssemblingTheMode(request);
        }
        else
        {
            if (NextHandler is not null)
            {
                return NextHandler.HandlerCommand(request);
            }
            else
            {
                return null;
            }
        }
    }
}