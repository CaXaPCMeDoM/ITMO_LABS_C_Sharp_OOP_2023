using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class SmallAsteroids : ISmallAsteroids, IAcceptableObstaclesForNormalSpace
{
    public SmallAsteroids()
    {
        Damage = 0;
    }

    public double Damage { get; }
}