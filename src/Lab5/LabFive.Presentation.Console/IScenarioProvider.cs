using System.Diagnostics.CodeAnalysis;

namespace LabFive.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}