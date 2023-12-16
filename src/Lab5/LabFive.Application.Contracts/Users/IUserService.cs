namespace LabFive.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);
    void CreatingAccount(string username, double userAmount, string userPassword);

    double? ViewingTheAccountBalanceByAccountId();

    void WithdrawingMoney(double amountToWithdraw);

    void AddingMoney(double amountToAdd);
}