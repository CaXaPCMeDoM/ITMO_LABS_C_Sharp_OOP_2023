namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassThird : Deflector
{
    public DeflectorClassThird()
        : base(1, 4, 41)
    {
        CosmoWhalesDamage = 40;
        AntimatterFlaresDamage = 100;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}