using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StateOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

public abstract class CommandHandlerBase
{
    protected static IFileCommand? FileCommand { get; set; }
    protected static FileInvoker? FileInvoker { get; set; }
    protected CommandHandlerBase? NextHandler { get; private set; }

    public void SetNextHandler(CommandHandlerBase nextHandler)
    {
        NextHandler = nextHandler;
    }

    public abstract void HandlerCommand(Request request);
}