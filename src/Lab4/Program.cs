using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        string? message = Console.ReadLine();
        var chairOfCommand = new ChairOfCommand();
        if (message != null)
        {
            Request request = Parse.Parser.ParserRequest(message);
            chairOfCommand.AssemblingTheChain(request);
        }
    }
}