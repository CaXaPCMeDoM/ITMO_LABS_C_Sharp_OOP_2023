using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestFifth
{
    private const string HeadingVariableMessage = "H123U6I4";
    private const string BodyVariableMessage = "NEHUI901421";
    private const int IdVariableMessage = 1;
    private const string NameTopicVariable = "Test topic";
    private const int ImportanceLevelVariable = 1;
    [Theory]
    [MemberData(nameof(LoggerResult))]
    public static void ReturnTheLogOfTheReceivedMessage(string expectedLog)
    {
        Message message = Message.Builder
            .WithId(IdVariableMessage)
            .WithHeading(HeadingVariableMessage)
            .WithBody(BodyVariableMessage)
            .ImportanceLevel(ImportanceLevelVariable)
            .Build();
        var loggerMock = new Mock<Logger.ILogger>();
        var userInAdressee = new User();
        var userAddresse = new LoggingOfTheAddressee(new UserAddresse(userInAdressee), loggerMock.Object);
        Topic topic = Topic.Builder
            .WithName(NameTopicVariable)
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();

        topic.SendMessageToTheAddressee(message);

        loggerMock.Verify(x => x.Log(expectedLog), Times.Once());
    }

    public static IEnumerable<object[]> LoggerResult()
    {
        yield return new object[]
        {
            HeadingVariableMessage + BodyVariableMessage,
        };
    }
}