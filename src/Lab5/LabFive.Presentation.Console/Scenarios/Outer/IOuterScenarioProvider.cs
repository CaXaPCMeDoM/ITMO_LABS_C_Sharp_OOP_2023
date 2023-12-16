using System.Diagnostics.CodeAnalysis;
using LabFive.Presentation.Console.Scenarios.Outer;

namespace LabFive.Presentation.Console;

public interface IOuterScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IOuterScenario? scenario);
}