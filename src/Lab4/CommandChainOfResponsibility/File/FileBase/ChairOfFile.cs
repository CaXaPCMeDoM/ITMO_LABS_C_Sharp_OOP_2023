using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileCopy;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileDelete;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileRename;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.File.FileBase;

public class ChairOfFile
{
    private FileCopyCommandHandler _fileCopyCommandHandler = new FileCopyCommandHandler();
    private FileDeleteCommandHandler _fileDeleteCommandHandler = new FileDeleteCommandHandler();
    private FileRenameCommandHandler _fileRenameCommandHandler = new FileRenameCommandHandler();
    private FileShowCommandHandler _fileShowCommandHandler = new FileShowCommandHandler();

    public ChairOfFile()
    {
        _fileCopyCommandHandler.SetNextMode(_fileDeleteCommandHandler);
        _fileDeleteCommandHandler.SetNextMode(_fileRenameCommandHandler);
        _fileRenameCommandHandler.SetNextMode(_fileShowCommandHandler);
    }

    public ICommand? AssemblingTheMode(Request request)
    {
        return _fileCopyCommandHandler.HandlerCommand(request);
    }
}