using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;

namespace LabFive.Presentation.Console.Scenarios.User.WithdrawMoney;

public class UserWithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public UserWithdrawMoneyScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserWithdrawMoneyScenario(_service);
        return true;
    }
}