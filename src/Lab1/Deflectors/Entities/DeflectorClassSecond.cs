namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassSecond : Deflector
{
    public DeflectorClassSecond()
        : base(3, 10, 31)
    {
    }

    protected override int CosmoWhalesDamage { get; } = 100;
    protected override int AntimatterFlaresDamage { get; } = 100;
}