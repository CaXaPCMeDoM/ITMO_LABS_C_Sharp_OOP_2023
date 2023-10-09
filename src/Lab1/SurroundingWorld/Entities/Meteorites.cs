namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class Meteorites : IObstacles
{
    public Meteorites()
    {
        Damage = 0;
    }

    public double Damage { get; }
}