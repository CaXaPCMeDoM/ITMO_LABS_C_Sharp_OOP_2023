using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

namespace Itmo.ObjectOrientedProgramming.Lab4.StartCommand;

public static class Start
{
    public static void Programm()
    {
        while (true)
        {
            string? message = Console.ReadLine();
            var chairOfCommand = new ChairOfCommand();
            if (message != null)
            {
                if (message == "exit")
                {
                    break;
                }

                Request request = Parse.Parser.ParserRequest(message);
                chairOfCommand.AssemblingTheChain(request);
            }
        }
    }
}