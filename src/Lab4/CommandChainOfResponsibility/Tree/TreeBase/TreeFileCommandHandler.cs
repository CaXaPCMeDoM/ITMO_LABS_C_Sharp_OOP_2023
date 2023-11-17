using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

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

    public override void HandlerCommand(Request request)
    {
        if (request.Arguments.ElementAtOrDefault(FirstWord) == FileConstString)
        {
            var chairmode = new ChairOfTree();
            chairmode.AssemblingTheMode(request);
        }
        else
        {
            NextHandler?.HandlerCommand(request);
        }
    }
}