using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

namespace Itmo.ObjectOrientedProgramming.Lab4.StartCommandProcessing;

public class StartInConsole : IStart
{
    public void Programm()
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

    public void Proframm()
    {
        throw new NotImplementedException();
    }
}