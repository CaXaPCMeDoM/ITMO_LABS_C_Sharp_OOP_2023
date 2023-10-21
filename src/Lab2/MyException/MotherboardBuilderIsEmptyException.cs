using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyException;

public class MotherboardBuilderIsEmptyException : Exception
{
    public MotherboardBuilderIsEmptyException()
        : base("MotherboardBuilder is empty")
    {
    }

    public MotherboardBuilderIsEmptyException(string message)
        : base(message)
    {
    }

    public MotherboardBuilderIsEmptyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}