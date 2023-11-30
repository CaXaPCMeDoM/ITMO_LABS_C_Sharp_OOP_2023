using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeGoTo;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;

public class ChairOfTree
{
    private TreeGoToCommandHandler _treeGoTo = new TreeGoToCommandHandler();
    private TreeListCommandHandler _treeList = new TreeListCommandHandler();
    public ChairOfTree()
    {
        _treeGoTo.SetNextMode(_treeList);
    }

    public ICommand? AssemblingTheMode(Request request)
    {
        return _treeGoTo.HandlerCommand(request);
    }
}