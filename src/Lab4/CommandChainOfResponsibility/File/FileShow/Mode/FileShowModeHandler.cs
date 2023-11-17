namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow.Mode;

public class FileShowModeHandler : FileShowCommandHandler
{
    protected new FileShowModeHandler? NextMode { get; private set; }

    public void SetNextMode(FileShowModeHandler modeHandler)
    {
        NextMode = modeHandler;
    }
}