namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class ClassThird : Deflectors
{
    public ClassThird()
        : base(1, 4, 41, true)
    {
    }

    protected override int CosmoWhalesDamage { get; } = 40;
    protected override int AntimatterFlaresDamage { get; } = 100;
}