namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IBodyBuilder
{
    IImportanceLevelBuilder WithBody(string body);
}