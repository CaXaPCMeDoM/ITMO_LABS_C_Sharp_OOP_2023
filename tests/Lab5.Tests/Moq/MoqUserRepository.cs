using System.Collections.ObjectModel;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

public class MoqUserRepository : IMoqUserRepository
{
    public double WithdrawingMoneyFromTheAccount(Collection<MoqUserTable> table, long id, double amountToWithdraw)
    {
        string sql;
        double amount = -1;
        foreach (MoqUserTable moqUserTable in table)
        {
            if (moqUserTable.Id == id)
            {
                sql = moqUserTable.Amount.ToString(CultureInfo.InvariantCulture);
                amount = moqUserTable.Amount - amountToWithdraw;
                break;
            }
        }

        return amount;
    }

    public double AddingFundsToYourAccount(Collection<MoqUserTable> table, long id, double amountToAdd)
    {
        string sql;
        double amount = -1;
        foreach (MoqUserTable moqUserTable in table)
        {
            if (moqUserTable.Id == id)
            {
                sql = moqUserTable.Amount.ToString(CultureInfo.InvariantCulture);
                amount = moqUserTable.Amount + amountToAdd;
                break;
            }
        }

        return amount;
    }
}