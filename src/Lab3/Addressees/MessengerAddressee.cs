using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : AddresseeComponent
{
    public override void ReceiveMessage(Message message)
    {
        IMessenger messenger = new Messenger();
        messenger.DataOutput(message.Body);
    }
}