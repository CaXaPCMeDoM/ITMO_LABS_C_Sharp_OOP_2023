using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class SmallAsteroids : ISmallAsteroids, IAcceptableObstaclesForNormalSpace
{
    public double Damage { get; }
}