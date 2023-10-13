using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassThird : Deflector
{
    private const int SmallAsteroidsDamageConst = 1;
    private const int MeteoritesDamageConst = 4;
    private const int HeatPointsConst = 41;
    private const int AntimatterFlaresDamageConst = 100;
    private const int CosmoWhalesDamageConst = 40;
    public DeflectorClassThird()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, HeatPointsConst)
    {
        CosmoWhalesDamage = CosmoWhalesDamageConst;
        AntimatterFlaresDamage = AntimatterFlaresDamageConst;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}