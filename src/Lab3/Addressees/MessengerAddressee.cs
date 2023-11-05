using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : AddresseeComponent
{
    public MessengerAddressee(ILogger logger)
        : base(logger)
    {
    }

    public override void ReceiveMessage(Message message)
    {
        Logger.Log(LoggerMessages.ReceivedMessage + $"{nameof(MessengerAddressee)}");
        IMessenger messenger = new Messenger();
        messenger.DataOutput(message.Body);
    }
}