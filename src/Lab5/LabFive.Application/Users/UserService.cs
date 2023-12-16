using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts;
using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _userRepository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username, string password)
    {
        User? user = _userRepository.LoginUserByUsernameAndPassword(username, password);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public void CreatingAccount(string username, double userAmount, string userPassword)
    {
        _currentUserManager.User = _userRepository.CreatingAccount(username, userAmount, userPassword);
    }

    public double? ViewingTheAccountBalanceByAccountId()
    {
        if (_currentUserManager.User != null)
        {
            return _userRepository.ViewingTheAccountBalanceByAccountId(_currentUserManager.User.Id);
        }
        else
        {
            return null;
        }
    }

    public void WithdrawingMoney(double amountToWithdraw)
    {
        if (_currentUserManager.User != null)
        {
            _userRepository.WithdrawingMoneyFromTheAccount(_currentUserManager.User.Id, amountToWithdraw);
        }
    }

    public void AddingMoney(double amountToAdd)
    {
        if (_currentUserManager.User != null)
        {
            _userRepository.AddingFundsToYourAccount(_currentUserManager.User.Id, amountToAdd);
        }
    }
}