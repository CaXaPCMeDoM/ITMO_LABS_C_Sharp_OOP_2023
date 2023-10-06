namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassThird : Deflectors
{
    public DeflectorClassThird()
        : base(1, 4, 41, true)
    {
        CosmoWhalesDamage = 40;
        AntimatterFlaresDamage = 100;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}