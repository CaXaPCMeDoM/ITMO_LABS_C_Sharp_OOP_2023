using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class NitronParticleNebulae : IEnvironment
{
    private IEnumerable<IObstacles> _obstaclesEnumerable;
    protected internal NitronParticleNebulae(double distance)
    {
        _obstaclesEnumerable = new List<IObstacles>();
        Distance = distance;
    }

    public IEnumerable<IObstacles> ObstaclesEnumerable => _obstaclesEnumerable;

    public double Distance { get; }
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
        if (obstacles is IAcceptableObstaclesForNitronParticleNebulae)
        {
            _obstaclesEnumerable = _obstaclesEnumerable.Concat(new[] { obstacles });
        }
    }
}