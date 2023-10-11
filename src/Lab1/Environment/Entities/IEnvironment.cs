using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public interface IEnvironment
{
    double Distance { get; }
    public Queue<IObstacles> ObstaclesQueue { get; }

    void AddObstacles(IObstacles obstacles);
    public bool EngineCompatibilityChecker(Engine engine);
}