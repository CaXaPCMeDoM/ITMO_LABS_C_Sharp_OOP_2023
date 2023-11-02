using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyException;

public class EmptyValuesException : Exception
{
    public EmptyValuesException()
        : base("Empty values")
    {
    }

    public EmptyValuesException(string message)
        : base(message)
    {
    }

    public EmptyValuesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}