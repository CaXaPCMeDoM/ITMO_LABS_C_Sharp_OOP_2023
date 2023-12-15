using System.Globalization;
using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.User.CreatingAnAccount;

public class UserCreatingAnAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public UserCreatingAnAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Creating an account";

    public void Run()
    {
        AnsiConsole.WriteLine("Введите имя пользователя:");
        string? username = System.Console.ReadLine();

        AnsiConsole.WriteLine("Введите сумму пользователя:");
        double userAmount = Convert.ToDouble(System.Console.ReadLine(), CultureInfo.InvariantCulture);

        AnsiConsole.WriteLine("Введите пароль пользователя:");
        string? userPassword = System.Console.ReadLine();

        if (username != null)
        {
            if (userPassword != null)
            {
                _userService.CreatingAccount(username, userAmount, userPassword);
            }
        }

        AnsiConsole.WriteLine("Ok");
    }
}