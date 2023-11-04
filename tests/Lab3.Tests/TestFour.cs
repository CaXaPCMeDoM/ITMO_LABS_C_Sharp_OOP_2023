using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFifthTest;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CopyForMocking.CloneForMockingForFourthTest;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestFour
{
    [Theory]
    [MemberData(nameof(LoggerResult))]
    public static void TheMessageDidNotFitTheCriteriaOfImportance(ResultTestForFourthTest filteringFailed)
    {
        AddresseeComponentCloneForFifthTest userAddresse = new UserAddresseCloneForFifthTest(ImportanceLevel.High);
        Message message = Message.Builder
            .WithId(1)
            .WithHeading("H123U6I4")
            .WithBody("NEHUI901421")
            .ImportanceLevelBuilder(ImportanceLevel.Low)
            .Build();
        TopicCloneForFifthTest topic = TopicCloneForFifthTest.Builder
            .WithName("IN1E32EB4U")
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();
        ResultTestForFourthTest resultTestForFourthTest = topic.SendMessageToTheAddressee(message);
        Assert.Equal(resultTestForFourthTest, filteringFailed);
    }

    public static IEnumerable<object[]> LoggerResult()
    {
        yield return new object[]
        {
            ResultTestForFourthTest.Mistake,
        };
    }
}