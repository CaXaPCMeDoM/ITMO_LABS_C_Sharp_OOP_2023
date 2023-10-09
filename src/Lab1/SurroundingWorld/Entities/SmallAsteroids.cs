namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class SmallAsteroids : IObstacles
{
    public SmallAsteroids()
    {
        Damage = 0;
    }

    public double Damage { get; }
}