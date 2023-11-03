namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IHeadingBuilder
{
    IBodyBuilder WithHeading(string heading);
}