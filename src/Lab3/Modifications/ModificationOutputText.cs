using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifications;

public class ModificationOutputText
{
    private string _text;
    public ModificationOutputText(string text)
    {
        _text = text;
    }

    public string Colored(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(_text);
        Console.ResetColor();

        return _text;
    }
}