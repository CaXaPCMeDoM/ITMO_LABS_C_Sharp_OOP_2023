using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddresse : AddresseeComponent
{
    public UserAddresse(ImportanceLevel importanceLevel, ILogger logger)
        : base(importanceLevel, logger)
    {
    }

    public User User { get; private set; } = new();
    public override void ReceiveMessage(Message message)
    {
        Logger.Log(LoggerMessages.ReceivedMessage + $"{nameof(UserAddresse)}");
        User.SetMessage(message);
    }
}