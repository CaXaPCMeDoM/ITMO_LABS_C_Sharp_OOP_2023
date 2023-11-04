using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public class GroupAddressee : AddresseeComponent
{
    private List<AddresseeComponent> _addressees;

    public GroupAddressee(ImportanceLevel importanceLevel, ILogger logger)
        : base(importanceLevel, logger)
    {
        _addressees = new List<AddresseeComponent>();
    }

    public void AddAddressee(AddresseeComponent addressee)
    {
        _addressees.Add(addressee);
    }

    public void RemoveAddressee(AddresseeComponent addressee)
    {
        _addressees.Remove(addressee);
    }

    public override void ReceiveMessage(Message message)
    {
        Logger.Log(LoggerMessages.ReceivedMessage + $"{nameof(GroupAddressee)}");
        foreach (AddresseeComponent addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}
