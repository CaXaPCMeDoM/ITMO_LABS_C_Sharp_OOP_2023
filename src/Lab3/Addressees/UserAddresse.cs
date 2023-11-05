using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddresse : AddresseeComponent
{
    public UserAddresse()
    {
    }

    public User User { get; private set; } = new();
    public override void ReceiveMessage(Message message)
    {
        User.SetMessage(message);
    }
}