using LabFive.Application.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

public interface IMoqUserService
{
    LoginResult Login(string username, string password);
    void CreatingAccount(string username, double userAmount, string userPassword);

    double? ViewingTheAccountBalanceByAccountId();

    void WithdrawingMoney(double amountToWithdraw);

    void AddingMoney(double amountToAdd);
}