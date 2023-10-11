using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class Meteorites : IMeteorites, ICanAddInNormalSpace
{
    public Meteorites()
    {
        Damage = 0;
    }

    public double Damage { get; }
}