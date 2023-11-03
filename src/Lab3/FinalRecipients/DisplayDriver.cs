using System;
using Itmo.ObjectOrientedProgramming.Lab3.Modifications;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public static class DisplayDriver
{
    private static string _text = string.Empty;
    public static void CleanOutput()
    {
        Console.Clear();
    }

    public static void SetText(string text)
    {
        _text += text;
    }

    public static string ChangeColorOutputText(ConsoleColor color)
    {
        var modificationOutputText = new ModificationOutputText(_text);
        _text = modificationOutputText.Colored(color);
        return _text;
    }
}