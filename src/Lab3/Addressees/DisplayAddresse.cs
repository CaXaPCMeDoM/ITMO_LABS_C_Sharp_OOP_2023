using System;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddresse : AddresseeComponent
{
    private ConsoleColor _color;
    public DisplayAddresse(ImportanceLevel importanceLevel, ConsoleColor color, ILogger logger)
        : base(importanceLevel, logger)
    {
        _color = color;
    }

    public override void ReceiveMessage(Message message)
    {
        Logger.Log(LoggerMessages.ReceivedMessage + $"{nameof(DisplayAddresse)}");
        var display = new Display(message);
        display.WriteTextWithColor(_color);
    }
}