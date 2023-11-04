using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class AddresseeComponent
{
    private ImportanceLevel _importanceLevel;

    protected AddresseeComponent(ImportanceLevel importanceLevel, ILogger logger)
    {
        _importanceLevel = importanceLevel;
        this.Logger = logger;
    }

    protected ILogger Logger { get; }

    public void AddMessage(Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            ReceiveMessage(message);
        }
    }

    public abstract void ReceiveMessage(Message message);
}