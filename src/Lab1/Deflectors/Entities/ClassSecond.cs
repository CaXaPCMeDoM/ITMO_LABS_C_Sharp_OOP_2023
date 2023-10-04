namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class ClassSecond : Deflectors
{
    public ClassSecond()
        : base(3, 10, 31, true)
    {
    }

    protected override int CosmoWhalesDamage { get; } = 100;
    protected override int AntimatterFlaresDamage { get; } = 100;
}