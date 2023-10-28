using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

public class CosmoWhales : ICosmoWhales, IAcceptableObstaclesForNitronParticleNebulae
{
    public double Damage { get; }
}