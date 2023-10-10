using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Path.Entities;

public class PathShip
{
    public Collection<IEnvironment> PathShipQueue { get; } = new Collection<IEnvironment>();
    public void AddPathShip(IEnvironment environment)
    {
        PathShipQueue.Add(environment);
    }
}