namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class AntimatterFlares : IObstacles
{
    public AntimatterFlares()
    {
        Damage = 0;
    }

    public double Damage { get; }
}