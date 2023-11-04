namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class Logger : ILogger
{
    public string Message { get; private set; } = string.Empty;
    public void Log(string message)
    {
        this.Message += message;
    }
}