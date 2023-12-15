using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;

namespace LabFive.Presentation.Console.Scenarios.User.Balance;

public class UserCheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public UserCheckBalanceScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserCheckBalanceScenario(_service);
        return true;
    }
}