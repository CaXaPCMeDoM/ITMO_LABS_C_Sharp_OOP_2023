using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class MarkUserMessageWithStatusNotReadShouldChangeStatus
{
    [Theory]
    [MemberData(nameof(StatusChange))]
    public static void Test(ResultAttemptMakrReadMessage resultAttemptMakrReadMessage)
    {
        UserAddresse? user;
        AddresseeComponent userAddresse = new UserAddresse(ImportanceLevel.High);
        Message message = Message.Builder
            .WithId(1)
            .WithHeading("HUI")
            .WithBody("NEHUI901421")
            .ImportanceLevelBuilder(ImportanceLevel.High)
            .Build();
        Topic topic = Topic.Builder
            .WithName("INEEBU")
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();
        topic.SendMessageToTheAddressee(message);
        user = (UserAddresse?)topic.AddresseeComponent;
        User? huesos = user?.User;
        if (huesos != null)
        {
            ResultAttemptMakrReadMessage readMessage = huesos.MarkAsRead(1);
            Assert.Equal(readMessage, resultAttemptMakrReadMessage);
        }
    }

    public static IEnumerable<object[]> StatusChange()
    {
        yield return new object[]
        {
            ResultAttemptMakrReadMessage.Successful,
        };
    }
}