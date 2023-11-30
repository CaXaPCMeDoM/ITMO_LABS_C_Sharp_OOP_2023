using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;

public class Request
{
    public Request(ICollection<string> arguments)
    {
        Arguments = new List<string>();
        Arguments = arguments;
    }

    public ICollection<string> Arguments { get; private set; }
}