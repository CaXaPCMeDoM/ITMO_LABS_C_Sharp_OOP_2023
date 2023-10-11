using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class HighDensityNebulae : IEnvironment
{
    protected internal HighDensityNebulae(int distance)
    {
        Distance = distance;
    }

    public double Distance { get; }
    Queue<IObstacles> IEnvironment.ObstaclesQueue { get; } = new Queue<IObstacles>();

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
        if (obstacles is ICanAddInHighDensityNebulae)
        {
            ((IEnvironment)this).ObstaclesQueue.Enqueue(obstacles);
        }
        else
        {
            // throw new ArgumentException("There can't be such objects of the 'obstacles' type in this 'environment'");
        }
    }
}