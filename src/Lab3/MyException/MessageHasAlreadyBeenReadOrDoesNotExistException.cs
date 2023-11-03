using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MyException;

public class MessageHasAlreadyBeenReadOrDoesNotExistException : Exception
{
    public MessageHasAlreadyBeenReadOrDoesNotExistException()
        : base("The message has already been read or does not exist")
    {
    }

    public MessageHasAlreadyBeenReadOrDoesNotExistException(string message)
        : base(message)
    {
    }

    public MessageHasAlreadyBeenReadOrDoesNotExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}