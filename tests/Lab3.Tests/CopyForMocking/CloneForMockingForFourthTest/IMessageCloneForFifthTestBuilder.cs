using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFourthTest;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface IMessageCloneForFifthTestBuilder
{
    IMessageCloneForFifthTestBuilder WithMessage(Message message);
    TopicCloneForFifthTest Build();
}