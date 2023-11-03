using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface IMessageBuilder
{
    IMessageBuilder WithMessage(Message message);
    Topic Build();
}