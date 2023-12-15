using System.Globalization;
using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.User.CheckBalance;

public class UserCheckBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public UserCheckBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Balance";

    public void Run()
    {
        double? result = _userService.ViewingTheAccountBalanceByAccountId();

        if (result != null)
        {
            AnsiConsole.WriteLine(CultureInfo.InvariantCulture, "{0}", result);
        }

        AnsiConsole.WriteLine("Ok");
    }
}