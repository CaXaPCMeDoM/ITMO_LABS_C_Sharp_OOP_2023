namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public enum RouteResults : int
{
    None,
    Success = 1,
    ShipIsLost = 2,
    ShipDestruction = 3,
    CrewIsDead = 4,
    EnginesNotSuitable = 5,
}