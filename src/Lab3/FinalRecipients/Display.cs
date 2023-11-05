using System;
using System.Reflection;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class Display : FinalRecipent
{
    private IDisplayDriver _displayDriver = new DisplayDriver();
    private ConsoleColor _color;

    public void SetColor(ConsoleColor color)
    {
        _color = color;
    }

    public void WriteTextWithColor(Message message)
    {
        string text = string.Empty;
        foreach (PropertyInfo property in message.GetType().GetProperties())
        {
            if (property.PropertyType == typeof(string))
            {
                text += (string?)property.GetValue(message) ?? string.Empty;
            }
        }

        _displayDriver.SetText(text);
        Console.WriteLine(_displayDriver.ChangeColorOutputText(_color));
        _displayDriver.CleanOutput();
        Console.ResetColor();
    }
}