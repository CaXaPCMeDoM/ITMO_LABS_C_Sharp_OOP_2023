using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class AntiNeutrinoEmitter : Deflector
{
    private const int SmallAsteroidsDamageConst = 0;
    private const int MeteoritesDamageConst = 0;
    private const int HeatPointsConst = 100;
    private const int AntimatterFlaresDamageConst = 0;
    private const int CosmoWhalesDamageConst = 99;
    public AntiNeutrinoEmitter()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, HeatPointsConst)
    {
        AntimatterFlaresDamage = AntimatterFlaresDamageConst;
        CosmoWhalesDamage = CosmoWhalesDamageConst;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}