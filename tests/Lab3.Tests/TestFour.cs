using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestFour
{
    [Theory]
    [MemberData(nameof(LoggerResult))]
    public static void TheMessageDidNotFitTheCriteriaOfImportance(ImportanceLevel level)
    {
        // Arrange
        Message message = Message.Builder
            .WithId(1)
            .WithHeading("H123U6I4")
            .WithBody("NEHUI901421")
            .ImportanceLevelBuilder(ImportanceLevel.Low)
            .Build();
        var loggerMock = new Mock<ILogger>();
        ILogger logger = loggerMock.Object;
        AddresseeComponent userAddresse = new FilterText(new UserAddresse(logger), level, logger);
        Topic topic = Topic.Builder
            .WithName("Test topic")
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();

        // Act
        topic.SendMessageToTheAddressee(message);

        // Assert
        loggerMock.Verify(log => log.Log(It.IsAny<string>()), Times.Never);
    }

    public static IEnumerable<object[]> LoggerResult()
    {
        yield return new object[]
        {
            ImportanceLevel.High,
        };
    }
}