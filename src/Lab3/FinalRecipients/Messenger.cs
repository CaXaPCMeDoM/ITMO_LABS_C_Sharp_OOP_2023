using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;

public class Messenger : FinalRecipent
{
    public static void DataOutput(Message message)
    {
        Console.WriteLine(message.Heading + message.Body);
    }
}