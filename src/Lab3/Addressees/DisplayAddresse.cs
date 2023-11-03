using System;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddresse : AddresseeComponent
{
    private ConsoleColor _color;
    public DisplayAddresse(ImportanceLevel importanceLevel, ConsoleColor color)
        : base(importanceLevel)
    {
        _color = color;
    }

    public override void ReceiveMessage(Message message)
    {
        var display = new Display(message);
        display.WriteTextWithColor(_color);
    }
}