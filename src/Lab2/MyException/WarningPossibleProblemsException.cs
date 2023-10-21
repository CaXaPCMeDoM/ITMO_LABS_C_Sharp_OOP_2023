using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyException;

public class WarningPossibleProblemsException : Exception
{
    public WarningPossibleProblemsException()
        : base("Warning")
    {
    }

    public WarningPossibleProblemsException(string message)
        : base(message)
    {
    }

    public WarningPossibleProblemsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}