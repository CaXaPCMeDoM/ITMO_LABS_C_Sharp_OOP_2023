using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.RouteShip.Entities;

public class PathShip
{
    private IEnumerable<IEnvironment> _pathShipEnumerable;

    public PathShip()
    {
        _pathShipEnumerable = new List<IEnvironment>();
    }

    public IEnumerable<IEnvironment> PathShipEnumerable => _pathShipEnumerable;

    public void AddPathShip(IEnvironment environment)
    {
        _pathShipEnumerable = _pathShipEnumerable.Concat(new[] { environment });
    }
}