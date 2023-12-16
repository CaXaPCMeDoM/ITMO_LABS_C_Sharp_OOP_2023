using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Admins;
using LabFive.Presentation.Console.Scenarios.Outer;

namespace LabFive.Presentation.Console.Scenarios.Admin;

public class AdminScenarioProvider : IOuterScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentUser;
    private readonly ScenarioRunner _scenarioRunner;

    public AdminScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentUser,
        ScenarioRunner scenarioRunner)
    {
        _service = service;
        _currentUser = currentUser;
        _scenarioRunner = scenarioRunner;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IOuterScenario? scenario)
    {
        if (_currentUser.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminScenario(_service, _scenarioRunner);
        return true;
    }
}