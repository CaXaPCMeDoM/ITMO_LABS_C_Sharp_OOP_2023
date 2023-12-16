using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

public interface IMoqUserRepository
{
    public double WithdrawingMoneyFromTheAccount(Collection<MoqUserTable> table, long id, double amountToWithdraw);
    double AddingFundsToYourAccount(Collection<MoqUserTable> table, long id, double amountToAdd);
}