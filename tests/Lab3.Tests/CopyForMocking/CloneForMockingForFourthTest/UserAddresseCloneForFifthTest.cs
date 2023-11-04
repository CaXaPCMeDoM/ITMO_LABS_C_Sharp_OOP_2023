using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFourthTest;

public class UserAddresseCloneForFifthTest : AddresseeComponentCloneForFifthTest
{
    public UserAddresseCloneForFifthTest(ImportanceLevel importanceLevel)
        : base(importanceLevel)
    {
    }

    public User User { get; private set; } = new();
    public override void ReceiveMessage(Message message)
    {
        MockingLogger.Log(LoggerMessages.ReceivedMessage + $"{nameof(UserAddresse)}");
        User.SetMessage(message);
    }
}