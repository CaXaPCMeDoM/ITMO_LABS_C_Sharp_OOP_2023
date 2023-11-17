using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeGoTo;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;

public class ChairOfTree
{
    private TreeGoToCommandHandler _treeGoTo = new TreeGoToCommandHandler();
    private TreeListCommandHandler _treeList = new TreeListCommandHandler();
    public ChairOfTree()
    {
        _treeGoTo.SetNextMode(_treeList);
    }

    public void AssemblingTheMode(Request request)
    {
        _treeGoTo.HandlerCommand(request);
    }
}