using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : AddresseeComponent
{
    public MessengerAddressee(ImportanceLevel importanceLevel)
        : base(importanceLevel)
    {
    }

    public override void ReceiveMessage(Message message)
    {
        Messenger.DataOutput(message);
    }
}