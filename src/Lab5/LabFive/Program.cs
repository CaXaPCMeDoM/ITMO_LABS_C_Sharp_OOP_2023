using LabFive.Application.Extensions;
using LabFive.Infastructure.DataAccess.Extensions;
using LabFive.Presentation.Console.Extensions;
using LabFive.Presentation.Console.Scenarios.Outer;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

OuterScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<OuterScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}