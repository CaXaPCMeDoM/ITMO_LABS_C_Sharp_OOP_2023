using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class Messenger : IMessenger
{
    public void DataOutput(string message)
    {
        Console.WriteLine(message);
    }
}