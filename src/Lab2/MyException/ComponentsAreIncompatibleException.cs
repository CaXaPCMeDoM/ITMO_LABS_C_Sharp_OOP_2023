using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyException;

public class ComponentsAreIncompatibleException : Exception
{
    public ComponentsAreIncompatibleException()
        : base()
    {
    }

    public ComponentsAreIncompatibleException(string message)
        : base(message)
    {
    }

    public ComponentsAreIncompatibleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}