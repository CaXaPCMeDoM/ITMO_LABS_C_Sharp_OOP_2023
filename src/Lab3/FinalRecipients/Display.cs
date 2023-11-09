using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class Display
{
    private IDisplayDriver _displayDriver = new DisplayDriver();
    private ConsoleColor _color;

    public void SetColor(ConsoleColor color)
    {
        _color = color;
    }

    public void WriteTextWithColor(Message message)
    {
        _displayDriver.SetText(message.Body);
        _displayDriver.SetText(message.Heading);
        Console.WriteLine(_displayDriver.ChangeColorOutputText(_color));

        _displayDriver.CleanOutput();
        Console.ResetColor();
    }
}