using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.FinalRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class MessagesAreSavedInTheStatusNotRead
{
    private const bool HaveResult = false;
    [Theory]
    [MemberData(nameof(StatusChange))]
    public static void Test(bool resultAttemptMakrReadMessage)
    {
        ILogger logger = new Logger.Logger();
        UserAddresse? userAddresseCopy;
        AddresseeComponent userAddresse = new UserAddresse(ImportanceLevel.High, logger);
        Message message = Message.Builder
            .WithId(1)
            .WithHeading("H123U6I4")
            .WithBody("NEHUI901421")
            .ImportanceLevelBuilder(ImportanceLevel.High)
            .Build();
        Topic topic = Topic.Builder
            .WithName("IN1E32EB4U")
            .WithAdress(userAddresse)
            .WithMessage(message)
            .Build();
        topic.SendMessageToTheAddressee(message);
        userAddresseCopy = (UserAddresse?)topic.AddresseeComponent;
        User? user = userAddresseCopy?.User;
        if (user != null)
        {
            bool readMessage = user.GetMessageStatus(1);
            Assert.Equal(readMessage, resultAttemptMakrReadMessage);
        }
    }

    public static IEnumerable<object[]> StatusChange()
    {
        yield return new object[]
        {
            HaveResult,
        };
    }
}