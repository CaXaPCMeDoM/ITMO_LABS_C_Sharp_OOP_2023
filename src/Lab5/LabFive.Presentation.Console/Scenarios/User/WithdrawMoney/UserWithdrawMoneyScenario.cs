using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.User.WithdrawMoney;

public class UserWithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public UserWithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw Money";

    public void Run()
    {
        AnsiConsole.WriteLine("How much should we withdraw: ");
        string? input = System.Console.ReadLine();
        if (double.TryParse(input, out double number))
        {
            _userService.WithdrawingMoney(number);
            AnsiConsole.WriteLine("Ok");
        }
    }
}