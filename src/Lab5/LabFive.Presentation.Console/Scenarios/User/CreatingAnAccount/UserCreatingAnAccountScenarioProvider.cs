using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;

namespace LabFive.Presentation.Console.Scenarios.User.CreatingAnAccount;

public class UserCreatingAnAccountScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public UserCreatingAnAccountScenarioProvider(
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

        scenario = new UserCreatingAnAccountScenario(_service);
        return true;
    }
}