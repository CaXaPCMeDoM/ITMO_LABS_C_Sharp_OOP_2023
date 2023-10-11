using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class NormalSpace : IEnvironment
{
    public NormalSpace(int distance)
    {
        Distance = distance;
    }

    public double Distance { get; }
    Collection<IObstacles> IEnvironment.ObstaclesCollection { get; } = new Collection<IObstacles>();

    public bool EngineCompatibilityChecker(Engine engine)
    {
        if (engine is ImpulseEngine)
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
        if (obstacles is ICanAddInNormalSpace)
        {
            ((IEnvironment)this).ObstaclesCollection.Add(obstacles);
        }
    }
}