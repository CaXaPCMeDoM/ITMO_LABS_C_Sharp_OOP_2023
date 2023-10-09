namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class AntiNeutrinoEmitter : Deflector
{
    public AntiNeutrinoEmitter()
        : base(0, 0, 100)
    {
        AntimatterFlaresDamage = 0;
    }

    protected override int CosmoWhalesDamage { get; } = 99;
    protected override int AntimatterFlaresDamage { get; }
}