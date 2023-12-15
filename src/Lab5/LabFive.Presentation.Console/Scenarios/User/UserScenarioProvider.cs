using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.Scenarios.Outer;

namespace LabFive.Presentation.Console.Scenarios.User;

public class UserScenarioProvider : IOuterScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ScenarioRunner _scenarioRunner;

    public UserScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser,
        ScenarioRunner scenarioRunner)
    {
        _service = service;
        _currentUser = currentUser;
        _scenarioRunner = scenarioRunner;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IOuterScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserScenario(_service, _scenarioRunner);
        return true;
    }
}