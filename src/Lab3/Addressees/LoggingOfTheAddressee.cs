using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class LoggingOfTheAddressee : AddresseeComponent
{
    public LoggingOfTheAddressee(AddresseeComponent addresseeComponent, ILogger logger)
    {
        AddresseeComponent = addresseeComponent;
        Logger = logger;
    }

    protected ILogger Logger { get; }
    protected AddresseeComponent AddresseeComponent { get; }
    public override void ReceiveMessage(Message message)
    {
        Logger.Log(message.Body + message.Heading);
    }
}