using System;
using Itmo.ObjectOrientedProgramming.Lab3.Modifications;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class DisplayDriver : IDisplayDriver
{
    private string _text = string.Empty;
    public void CleanOutput()
    {
        Console.Clear();
        _text = string.Empty;
    }

    public void SetText(string text)
    {
        _text += text;
    }

    public string ChangeColorOutputText(ConsoleColor color)
    {
        var modificationOutputText = new ModificationOutputText(_text);
        Console.ForegroundColor = color;
        _text = modificationOutputText.Colored(color);
        return _text;
    }

    public void WriteTextToConsole(string text)
    {
        Console.WriteLine(text);
    }
}