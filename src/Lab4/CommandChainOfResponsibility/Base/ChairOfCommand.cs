using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Connect.ConnectBase;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Tree.TreeBase;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

public class ChairOfCommand
{
    private CommandHandlerBase _connectFileCommand = new ConnectFileCommandHandler();
    private CommandHandlerBase _disconnectFileCommand = new DisconnectFileCommandHandler();
    private CommandHandlerBase _fileCommand = new FileCommandHandler();
    private CommandHandlerBase _treeFileCommand = new TreeFileCommandHandler();

    public ChairOfCommand()
    {
        _connectFileCommand.SetNextHandler(
            _disconnectFileCommand.SetNextHandler(
                _disconnectFileCommand.SetNextHandler(
                    _fileCommand.SetNextHandler(_treeFileCommand))));
    }

    public ICommand? AssemblingTheChain(Request request)
    {
        return _connectFileCommand.HandlerCommand(request);
    }
}