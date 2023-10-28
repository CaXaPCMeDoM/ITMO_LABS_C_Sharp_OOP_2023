using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class Meteorite : IMeteorites, IAcceptableObstaclesForNormalSpace
{
    public double Damage { get; }
}