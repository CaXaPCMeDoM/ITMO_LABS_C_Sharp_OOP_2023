using LabFive.Presentation.Console.Scenarios.Admin;
using LabFive.Presentation.Console.Scenarios.Admin.HistoryOperation;
using LabFive.Presentation.Console.Scenarios.Outer;
using LabFive.Presentation.Console.Scenarios.User;
using LabFive.Presentation.Console.Scenarios.User.AddMoney;
using LabFive.Presentation.Console.Scenarios.User.CheckBalance;
using LabFive.Presentation.Console.Scenarios.User.CreatingAnAccount;
using LabFive.Presentation.Console.Scenarios.User.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace LabFive.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<OuterScenarioRunner>();

        collection.AddScoped<IOuterScenarioProvider, UserScenarioProvider>();
        collection.AddScoped<IOuterScenarioProvider, AdminScenarioProvider>();

        collection.AddScoped<IScenarioProvider, UserCheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserAddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserCreatingAnAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserWithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminGetHistoryOperationScenarioProvider>();

        return collection;
    }
}