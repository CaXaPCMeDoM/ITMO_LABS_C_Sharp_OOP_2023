namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class CosmoWhales : IObstacles
{
    public CosmoWhales()
    {
        Damage = 0;
    }

    public double Damage { get; }
}