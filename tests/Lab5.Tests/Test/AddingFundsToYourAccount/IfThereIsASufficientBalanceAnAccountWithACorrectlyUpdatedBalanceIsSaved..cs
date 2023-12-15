using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;
using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Test.AddingFundsToYourAccount;

public class IfThereIsASufficientBalanceAnAccountWithACorrectlyUpdatedBalanceIsSaved_
{
    [Theory]
    [MemberData(nameof(TestData))]
    public static void Test()
    {
        // Arrange
        var mockRepo = new Mock<IMoqUserRepository>();
        IMoqCurrentUserService currentUserManager = new MoqCurrentUserManager();
        IUserService userService = new MoqUserService(mockRepo.Object, currentUserManager);
        MoqUserTable
        var user = new User (Id: 1, Username: "Vanya", Amount: 1000, Password: "1234");
        currentUserManager.User = user;
        mockRepo.Setup(r => r.WithdrawingMoneyFromTheAccount(user.Id, It.IsAny<double>())).Callback((long id, double amount) => user.Balance -= amount);

        // Act
        userService.WithdrawingMoney(200);

        // Assert
        Assert.AreEqual(800, user.Amount);
        mockRepo.Verify(r => r.WithdrawingMoneyFromTheAccount(user.Id, 200), Times.Once);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            
        };
    }
}