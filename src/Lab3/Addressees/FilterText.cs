using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class FilterText : AddresseeComponent
{
    private int _importanceLevel;
    private AddresseeComponent _addresseeComponent;

    public FilterText(AddresseeComponent addresseeComponent, int importanceLevel)
    {
        _importanceLevel = importanceLevel;
        _addresseeComponent = addresseeComponent;
    }

    public override void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            _addresseeComponent.ReceiveMessage(message);
        }
    }
}