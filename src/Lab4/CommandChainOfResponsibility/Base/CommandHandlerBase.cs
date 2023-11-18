using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

public abstract class CommandHandlerBase
{
    protected static IFileCommand? FileCommand { get; set; }
    protected static FileInvoker? FileInvoker { get; set; }
    protected CommandHandlerBase? NextHandler { get; private set; }

    public CommandHandlerBase SetNextHandler(CommandHandlerBase nextHandler)
    {
        if (NextHandler is null)
        {
            NextHandler = nextHandler;
        }
        else
        {
            NextHandler.SetNextHandler(nextHandler);
        }

        return this;
    }

    public abstract ICommand? HandlerCommand(Request request);
}