namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class AntiNeutrinoEmitter : Deflectors
{
    public AntiNeutrinoEmitter()
        : base(0, 0, 100, true)
    {
        AntimatterFlaresDamage = 0;
    }

    protected override int CosmoWhalesDamage { get; } = 99;
    protected override int AntimatterFlaresDamage { get; }
}