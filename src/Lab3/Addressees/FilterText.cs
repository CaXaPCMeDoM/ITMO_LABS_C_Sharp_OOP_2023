using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class FilterText : AddresseeComponent
{
    private int _importanceLevel;

    public FilterText(AddresseeComponent addresseeComponent, int importanceLevel)
    {
        this._importanceLevel = importanceLevel;
        AddresseeComponent = addresseeComponent;
    }

    protected AddresseeComponent AddresseeComponent { get; }

    public override void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            AddresseeComponent.ReceiveMessage(message);
        }
    }
}