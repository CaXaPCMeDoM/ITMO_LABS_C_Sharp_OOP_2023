using LabFive.Application.Models.Users;

namespace LabFive.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
    User? CreatingAccount(string username, double useramount, string userpassword);
    double? ViewingTheAccountBalanceByAccountId(long id);
    void WithdrawingMoneyFromTheAccount(long id, double amountToWithdraw);
    void AddingFundsToYourAccount(long id, double amountToAdd);
}