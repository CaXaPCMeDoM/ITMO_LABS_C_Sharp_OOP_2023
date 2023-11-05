using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class AddresseeComponent
{
    public abstract void ReceiveMessage(Message message);
}