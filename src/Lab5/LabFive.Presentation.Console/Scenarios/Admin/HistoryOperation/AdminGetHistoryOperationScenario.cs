using System.Globalization;
using LabFive.Application.Contracts.Admins;
using LabFive.Application.Models.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.Admin.HistoryOperation;

public class AdminGetHistoryOperationScenario : IScenario
{
    private readonly IAdminService _userService;

    public AdminGetHistoryOperationScenario(IAdminService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        AnsiConsole.WriteLine("Введите параметр:");
        string? input = System.Console.ReadLine();
        if (input != null)
        {
            long userId = long.Parse(input, CultureInfo.InvariantCulture);

            IEnumerable<OperationDetail> result = _userService.GetHistoryOperation(userId);

            if (result != null)
            {
                foreach (OperationDetail operation in result)
                {
                    AnsiConsole.WriteLine(CultureInfo.InvariantCulture, "{0}", operation);
                }
            }
        }

        AnsiConsole.WriteLine("Ok");
    }
}