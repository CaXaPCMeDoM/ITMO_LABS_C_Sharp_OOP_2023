namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IImportanceLevelBuilder
{
    IImportanceLevelBuilder ImportanceLevelBuilder(ImportanceLevel importanceLevel);
    Message Build();
}