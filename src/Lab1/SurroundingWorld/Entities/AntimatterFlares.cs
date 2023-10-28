// using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class AntimatterFlares : IAntimatterFlares, IAcceptableObstaclesForHighDensityNebulae
{
    public double Damage { get; }
}