using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;

public class FileCommandHandler : CommandHandlerBase
{
    private const int FirstWord = 0;
    private const string FileConstString = "file";
    protected FileCommandHandler? NextMode { get; private set; }
    public void SetNextMode(FileCommandHandler modeHandler)
    {
        NextMode = modeHandler;
    }

    public override void HandlerCommand(Request request)
    {
        string? firstWord = request.Arguments.ElementAtOrDefault(FirstWord);
        if (firstWord != null
            && firstWord.Equals(FileConstString, StringComparison.Ordinal))
        {
            var chairMode = new ChairOfFile();
            chairMode.AssemblingTheMode(request);
        }
        else
        {
            NextHandler?.HandlerCommand(request);
        }
    }
}