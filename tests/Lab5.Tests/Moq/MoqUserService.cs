using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

internal class MoqUserService : IMoqUserService
{
    private readonly IMoqUserRepository _userRepository;
    private readonly MoqCurrentUserManager _currentUserManager;

    public MoqUserService(IMoqUserRepository repository, MoqCurrentUserManager currentUserManager)
    {
        _userRepository = repository;
        _currentUserManager = currentUserManager;
    }

    public double WithdrawingMoney(Collection<MoqUserTable> table, double amountToWithdraw)
    {
        return _userRepository.WithdrawingMoneyFromTheAccount(table, table[0].Id, amountToWithdraw);
    }

    public double AddingMoney(Collection<MoqUserTable> table, double amountToAdd)
    {
        return _userRepository.AddingFundsToYourAccount(table, table[0].Id, amountToAdd);
    }
}