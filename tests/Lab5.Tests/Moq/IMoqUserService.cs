using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

public interface IMoqUserService
{
    public double WithdrawingMoney(Collection<MoqUserTable> table, double amountToWithdraw);

    public double AddingMoney(Collection<MoqUserTable> table, double amountToAdd);
}