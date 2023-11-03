using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : AddresseeComponent
{
    private List<AddresseeComponent> _addressees;

    public GroupAddressee(ImportanceLevel importanceLevel)
        : base(importanceLevel)
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
        foreach (AddresseeComponent addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}