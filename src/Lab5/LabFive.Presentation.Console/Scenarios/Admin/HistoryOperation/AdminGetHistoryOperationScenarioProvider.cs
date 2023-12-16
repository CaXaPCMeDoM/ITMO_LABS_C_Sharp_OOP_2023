using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Admins;

namespace LabFive.Presentation.Console.Scenarios.Admin.HistoryOperation;

public class AdminGetHistoryOperationScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentUser;

    public AdminGetHistoryOperationScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminGetHistoryOperationScenario(_service);
        return true;
    }
}