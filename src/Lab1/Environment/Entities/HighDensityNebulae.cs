using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class HighDensityNebulae : IEnvironment
{
    protected internal HighDensityNebulae(double distance)
    {
        Distance = distance;
    }

    public double Distance { get; }
    public IEnumerable<IObstacles> ObstaclesEnumerable { get; private set; } = Enumerable.Empty<IObstacles>();

    public bool EngineCompatibilityChecker(Engine engine)
    {
        if (engine is JumpEngine)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddObstacles(IObstacles obstacles)
    {
        if (obstacles is IAcceptableObstaclesForHighDensityNebulae)
        {
            ObstaclesEnumerable = ObstaclesEnumerable.Concat(new[] { obstacles });
        }
    }
}