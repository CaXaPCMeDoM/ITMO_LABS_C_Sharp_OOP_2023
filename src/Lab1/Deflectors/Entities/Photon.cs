using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class Photon : Deflector
{
    private const int SmallAsteroidsDamageConst = 0;
    private const int MeteoritesDamageConst = 0;
    private const int HeatPointsConst = 100;
    private const int AntimatterFlaresDamageConst = 33;
    private const int CosmoWhalesDamageConst = 0;
    public Photon()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, HeatPointsConst)
    {
        CosmoWhalesDamage = CosmoWhalesDamageConst;
        AntimatterFlaresDamage = AntimatterFlaresDamageConst;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}