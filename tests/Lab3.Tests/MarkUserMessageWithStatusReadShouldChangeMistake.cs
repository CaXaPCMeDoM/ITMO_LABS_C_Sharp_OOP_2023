using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class MarkUserMessageWithStatusReadShouldChangeMistake
{
    private const string HeadingVariableMessage = "H123U6I4";
    private const string BodyVariableMessage = "NEHUI901421";
    private const int IdVariableMessage = 1;
    private const string NameTopicVariable = "Test topic";
    private const int ImportanceLevelVariable = 1;
    [Theory]
    [MemberData(nameof(StatusChange))]
    public static void Test(ResultAttemptMakrReadMessage resultAttemptMakrReadMessage)
    {
        UserAddresse? userAddresseCopy;
        AddresseeComponent userAddresse = new UserAddresse();
        Message message = Message.Builder
            .WithId(IdVariableMessage)
            .WithHeading(HeadingVariableMessage)
            .WithBody(BodyVariableMessage)
            .ImportanceLevel(ImportanceLevelVariable)
            .Build();
        Topic topic = Topic.Builder
            .WithName(NameTopicVariable)
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();
        topic.SendMessageToTheAddressee(message);
        userAddresseCopy = (UserAddresse?)topic.AddresseeComponent;
        User? user = userAddresseCopy?.User;
        if (user != null)
        {
            ResultAttemptMakrReadMessage readMessage;
            user.MarkAsRead(1);
            readMessage = user.MarkAsRead(1);
            Assert.Equal(readMessage, resultAttemptMakrReadMessage);
        }
    }

    public static IEnumerable<object[]> StatusChange()
    {
        yield return new object[]
        {
            ResultAttemptMakrReadMessage.Mistake,
        };
    }
}