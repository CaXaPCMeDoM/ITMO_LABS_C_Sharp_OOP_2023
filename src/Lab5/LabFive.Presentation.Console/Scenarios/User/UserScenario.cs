using LabFive.Application.Contracts;
using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.Scenarios.Outer;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.User;

public class UserScenario : IOuterScenario
{
    private readonly IUserService _userService;
    private readonly ScenarioRunner _scenarioRunner;

    public UserScenario(IUserService userService, ScenarioRunner scenarioRunner)
    {
        _userService = userService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = _userService.Login(username, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
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