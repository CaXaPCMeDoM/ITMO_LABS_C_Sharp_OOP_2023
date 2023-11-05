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
    private const string HeadingVariableMessage = "H123U6I4";
    private const string BodyVariableMessage = "NEHUI901421";
    private const int IdVariableMessage = 1;
    private const string NameTopicVariable = "Test topic";
    private const int ImportanceLevelFirstVariable = 1;
    private const int ImportanceLevelSecondVariable = 2;
    [Theory]
    [MemberData(nameof(LoggerResult))]
    public static void TheMessageDidNotFitTheCriteriaOfImportance(int level)
    {
        // Arrange
        Message message = Message.Builder
            .WithId(IdVariableMessage)
            .WithHeading(HeadingVariableMessage)
            .WithBody(BodyVariableMessage)
            .ImportanceLevel(ImportanceLevelFirstVariable)
            .Build();
        var loggerMock = new Mock<ILogger>();
        ILogger logger = loggerMock.Object;
        AddresseeComponent userAddresse = new FilterText(new UserAddresse(), level);
        Topic topic = Topic.Builder
            .WithName(NameTopicVariable)
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
            ImportanceLevelSecondVariable,
        };
    }
}