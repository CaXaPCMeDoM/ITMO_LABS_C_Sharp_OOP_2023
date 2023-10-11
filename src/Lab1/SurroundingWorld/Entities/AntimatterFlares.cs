// using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class AntimatterFlares : IAntimatterFlares, ICanAddInHighDensityNebulae
{
    public AntimatterFlares()
    {
        Damage = 0;
    }

    public double Damage { get; }
}