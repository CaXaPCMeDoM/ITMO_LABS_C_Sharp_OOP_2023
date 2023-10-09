namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassFirst : Deflector
{
    public DeflectorClassFirst()
        : base(5, 10, 11)
    {
    }

    protected override int CosmoWhalesDamage { get; } = 100;
    protected override int AntimatterFlaresDamage { get; } = 100;
}