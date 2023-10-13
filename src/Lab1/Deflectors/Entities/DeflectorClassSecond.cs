using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassSecond : Deflector
{
    private const int SmallAsteroidsDamageConst = 3;
    private const int MeteoritesDamageConst = 10;
    private const int HeatPointsConst = 31;
    private const int AntimatterFlaresDamageConst = 100;
    private const int CosmoWhalesDamageConst = 100;
    public DeflectorClassSecond()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, HeatPointsConst)
    {
        CosmoWhalesDamage = CosmoWhalesDamageConst;
        AntimatterFlaresDamage = AntimatterFlaresDamageConst;
    }

    protected override int CosmoWhalesDamage { get; } = 100;
    protected override int AntimatterFlaresDamage { get; } = 100;
}