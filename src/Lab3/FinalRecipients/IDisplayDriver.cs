using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public interface IDisplayDriver
{
    public void CleanOutput();

    public void SetText(string text);

    public string ChangeColorOutputText(ConsoleColor color);
}