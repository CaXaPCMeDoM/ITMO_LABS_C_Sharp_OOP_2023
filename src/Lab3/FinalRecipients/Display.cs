using System;
using System.Reflection;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class Display : FinalRecipent
{
    private Message _message;
    public Display(Message message)
    {
        _message = message;
    }

    public void WriteTextWithColor(ConsoleColor color)
    {
        string text = string.Empty;
        foreach (PropertyInfo property in _message.GetType().GetProperties())
        {
            if (property.PropertyType == typeof(string))
            {
                text += (string?)property.GetValue(_message) ?? string.Empty;
            }
        }

        DisplayDriver.SetText(text);
        Console.WriteLine(DisplayDriver.ChangeColorOutputText(color));
        DisplayDriver.CleanOutput();
    }
}