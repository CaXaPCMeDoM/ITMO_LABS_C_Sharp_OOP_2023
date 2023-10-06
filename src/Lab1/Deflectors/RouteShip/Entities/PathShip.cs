using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Path.Entities;

public class PathShip
{
    public Queue<IEnvironment> PathShipQueue { get; } = new Queue<IEnvironment>();
    public void AddPathShip(IEnvironment environment)
    {
        PathShipQueue.Enqueue(environment);
    }
}