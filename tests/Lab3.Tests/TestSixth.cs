using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Auxiliary;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestSixth
{
    [Theory]
    [MemberData(nameof(LoggerResult))]
    public static void SendingAMessageToAMessenger(string expectedLog)
    {
        Message message = Message.Builder
            .WithId(1)
            .WithHeading("H123U6I4")
            .WithBody("NEHUI901421")
            .ImportanceLevelBuilder(ImportanceLevel.High)
            .Build();
        var loggerMock = new Mock<Itmo.ObjectOrientedProgramming.Lab3.Logger.ILogger>();
        var messengerAddressee = new MessengerAddressee(ImportanceLevel.High, loggerMock.Object);
        Topic topic = Topic.Builder
            .WithName("Test topic")
            .WithAdress(messengerAddressee)
            .WithMessage(message)
            .Build();

        topic.SendMessageToTheAddressee(message);

        loggerMock.Verify(x => x.Log(expectedLog), Times.Once());
    }

    public static IEnumerable<object[]> LoggerResult()
    {
        yield return new object[]
        {
            LoggerMessages.ReceivedMessage + $"{nameof(MessengerAddressee)}",
        };
    }
}