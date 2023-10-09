namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class Photon : Deflector
{
    public Photon()
        : base(0, 0, 100)
    {
        CosmoWhalesDamage = 0;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; } = 33;
}