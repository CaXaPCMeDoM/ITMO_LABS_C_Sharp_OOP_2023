using LabFive.Application.Contracts;
using LabFive.Application.Contracts.Admins;
using LabFive.Presentation.Console.Scenarios.Outer;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.Admin;

public class AdminScenario : IOuterScenario
{
    private readonly IAdminService _adminService;
    private readonly ScenarioRunner _scenarioRunner;

    public AdminScenario(IAdminService adminService, ScenarioRunner scenarioRunner)
    {
        _adminService = adminService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Admin";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your Admin Password");

        LoginResult result = _adminService.Login(username);

        string message = result switch
        {
            LoginResult.Success => "Successful password",
            LoginResult.NotFound => "Incorrect password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("Ok");
        while (true)
        {
            _scenarioRunner.Run();
        }
    }
}