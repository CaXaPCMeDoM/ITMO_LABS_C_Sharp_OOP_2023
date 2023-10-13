using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class DeflectorClassFirst : Deflector
{
    private const int SmallAsteroidsDamageConst = 5;
    private const int MeteoritesDamageConst = 10;
    private const int HeatPointsConst = 11;
    private const int AntimatterFlaresDamageConst = 100;
    private const int CosmoWhalesDamageConst = 100;

    public DeflectorClassFirst()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, HeatPointsConst)
    {
        CosmoWhalesDamage = CosmoWhalesDamageConst;
        AntimatterFlaresDamage = AntimatterFlaresDamageConst;
    }

    protected override int CosmoWhalesDamage { get; }
    protected override int AntimatterFlaresDamage { get; }
}