using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class AddresseeComponent
{
    protected AddresseeComponent(ILogger logger)
    {
        this.Logger = logger;
    }

    protected ILogger Logger { get; }

    public abstract void ReceiveMessage(Message message);
}