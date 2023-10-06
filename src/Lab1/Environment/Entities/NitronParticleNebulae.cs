using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class NitronParticleNebulae : IEnvironment
{
    public NitronParticleNebulae(int distance) => Distance = distance;
    public double Distance { get; set; }
    Queue<IObstacles> IEnvironment.ObstaclesQueue { get; } = new Queue<IObstacles>();

    public bool EngineCompatibilityChecker(Engine engine)
    {
        if (engine is ImpulseEngineE)
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
        if (obstacles is not CosmoWhales)
        {
            // throw new ArgumentException("There can't be such objects of the 'obstacles' type in this 'environment'");
        }
        else
        {
            ((IEnvironment)this).ObstaclesQueue.Enqueue(obstacles);
        }
    }
}