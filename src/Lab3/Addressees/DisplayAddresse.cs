using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddresse : AddresseeComponent
{
    private Display _display;
    public DisplayAddresse(Display display)
    {
        _display = display;
    }

    public override void ReceiveMessage(Message message)
    {
        _display.WriteTextWithColor(message);
    }
}