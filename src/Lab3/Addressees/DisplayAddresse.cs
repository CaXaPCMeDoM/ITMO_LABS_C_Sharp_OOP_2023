using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddresse : AddresseeComponent
{
    private Display display = new Display();
    public override void ReceiveMessage(Message message)
    {
        display.WriteTextWithColor(message);
    }
}