namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IImportanceLevelBuilder
{
    IImportanceLevelBuilder ImportanceLevel(int importanceLevel);
    Message Build();
}