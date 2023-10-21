using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyException;

public class ObstaclesNotFoundException : Exception
{
    public ObstaclesNotFoundException()
        : base("Obstacles not found")
    {
    }

    public ObstaclesNotFoundException(string message)
        : base(message)
    {
    }

    public ObstaclesNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}