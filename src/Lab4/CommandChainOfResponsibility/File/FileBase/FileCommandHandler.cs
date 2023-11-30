using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;

public class FileCommandHandler : CommandHandlerBase
{
    private const int FirstWord = 0;
    private const string FileConstString = "file";
    protected FileCommandHandler? NextMode { get; private set; }
    public FileCommandHandler SetNextMode(FileCommandHandler modeHandler)
    {
        if (NextMode is null)
        {
            NextMode = modeHandler;
        }
        else
        {
            NextMode.SetNextHandler(modeHandler);
        }

        return this;
    }

    public override ICommand? HandlerCommand(Request request)
    {
        string? firstWord = request.Arguments.ElementAtOrDefault(FirstWord);
        if (firstWord != null
            && firstWord.Equals(FileConstString, StringComparison.Ordinal))
        {
            var chairMode = new ChairOfFile();
            return chairMode.AssemblingTheMode(request);
        }
        else
        {
            if (NextHandler is not null)
            {
                return NextHandler.HandlerCommand(request);
            }
            else
            {
                return null;
            }
        }
    }
}