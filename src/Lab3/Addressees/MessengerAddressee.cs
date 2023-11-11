using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : AddresseeComponent
{
    private IMessenger _messenger;
    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public override void ReceiveMessage(Message message)
    {
        _messenger.MessageDataOutput(message.Body);
    }
}