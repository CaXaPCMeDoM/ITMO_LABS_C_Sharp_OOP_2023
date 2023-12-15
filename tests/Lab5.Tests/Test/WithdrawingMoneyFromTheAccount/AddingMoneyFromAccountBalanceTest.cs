using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Test.WithdrawingMoneyFromTheAccount;

public static class AddingMoneyFromAccountBalanceTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public static void Test(int value)
    {
        // Arrange
        var mockRepo = new Mock<IMoqUserRepository>();
        var moqUserRepository = new MoqUserRepository();
        var currentUserManager = new MoqCurrentUserManager();
        var moqUserTables = new Collection<MoqUserTable>();
        var moqUserTable = new MoqUserTable(Id: 1, Name: "Vanya", Amount: 800, Password: "1234");
        moqUserTables.Add(moqUserTable);
        double tmpAmount = moqUserTable.Amount;
        var userService = new MoqUserService(moqUserRepository, currentUserManager);
        mockRepo.Setup(r => r.AddingFundsToYourAccount(moqUserTables, moqUserTable.Id, value));

        // Act
        tmpAmount = userService.AddingMoney(moqUserTables, value);

        // Assert
        Assert.Equal(1000, tmpAmount);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            200,
        };
    }
}