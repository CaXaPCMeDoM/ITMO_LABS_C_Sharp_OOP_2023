using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Test.AddingFundsToYourAccount;

public static class WithdrawingAccountBalanceUpdateTest
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
        var moqUserTable = new MoqUserTable(Id: 1, Name: "Vanya", Amount: 1000, Password: "1234");
        moqUserTables.Add(moqUserTable);
        double tmpAmount = moqUserTable.Amount;
        var userService = new MoqUserService(moqUserRepository, currentUserManager);
        mockRepo.Setup(r => r.WithdrawingMoneyFromTheAccount(moqUserTables, moqUserTable.Id, value));

        // Act
        tmpAmount = userService.WithdrawingMoney(moqUserTables, value);

        // Assert
        Assert.Equal(800, tmpAmount);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            200,
        };
    }
}