using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.RouteShip.Entities;

public class PathShip
{
    public IEnumerable<IEnvironment> PathShipEnumerable { get; private set; } = Enumerable.Empty<IEnvironment>();

    public void AddPathShip(IEnvironment environment)
    {
        PathShipEnumerable = PathShipEnumerable.Concat(new[] { environment });
    }
}