using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.User.AddMoney;

public class UserAddMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public UserAddMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Add money";

    public void Run()
    {
        AnsiConsole.WriteLine("How much should we add: ");
        string? input = System.Console.ReadLine();
        if (double.TryParse(input, out double number))
        {
            _userService.AddingMoney(number);
            AnsiConsole.WriteLine("Ok");
        }
    }
}