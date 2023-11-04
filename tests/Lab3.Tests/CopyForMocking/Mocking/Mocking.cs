namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.Mocking;

public class Mocking : IMocking
{
    public string Message { get; private set; } = string.Empty;
    public void Log(string message)
    {
        this.Message += message;
    }
}