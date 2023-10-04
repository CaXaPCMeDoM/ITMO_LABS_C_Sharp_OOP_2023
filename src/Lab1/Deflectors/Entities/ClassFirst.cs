namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class ClassFirst : Deflectors
{
    public ClassFirst()
        : base(5, 10, 11, true)
    {
    }

    protected override int CosmoWhalesDamage { get; } = 100;
    protected override int AntimatterFlaresDamage { get; } = 100;
}