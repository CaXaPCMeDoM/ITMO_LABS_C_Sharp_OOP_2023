namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class Photon : Deflectors
{
    public Photon()
        : base(0, 0, 100, true)
    {
        CosmoWhalesDamage = 0;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; } = 33;
}