namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class AntineutrineEmitter : Deflectors
{
    public AntineutrineEmitter()
        : base(0, 0, 100, true)
    {
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; } = 100;
}