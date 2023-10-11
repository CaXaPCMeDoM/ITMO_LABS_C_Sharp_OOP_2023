using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public interface IEnvironment
{
    double Distance { get; }
    public Collection<IObstacles> ObstaclesCollection { get; }

    void AddObstacles(IObstacles obstacles);
    public bool EngineCompatibilityChecker(Engine engine);
}