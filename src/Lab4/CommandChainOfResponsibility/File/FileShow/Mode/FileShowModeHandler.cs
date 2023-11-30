namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;

public class FileShowModeHandler : FileShowCommandHandler
{
    protected new FileShowModeHandler? NextMode { get; private set; }

    public FileShowModeHandler SetNextMode(FileShowModeHandler modeHandler)
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
}