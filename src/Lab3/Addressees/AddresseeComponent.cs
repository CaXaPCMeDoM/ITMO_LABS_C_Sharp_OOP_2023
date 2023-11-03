using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class AddresseeComponent
{
    private ImportanceLevel _importanceLevel;

    protected AddresseeComponent(ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
    }

    public void AddMessage(Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            ReceiveMessage(message);
        }
    }

    public abstract void ReceiveMessage(Message message);
}