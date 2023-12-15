using LabFive.Presentation.Console.Scenarios.Admin;
using LabFive.Presentation.Console.Scenarios.User;
using LabFive.Presentation.Console.Scenarios.User.Balance;
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

        return collection;
    }
}