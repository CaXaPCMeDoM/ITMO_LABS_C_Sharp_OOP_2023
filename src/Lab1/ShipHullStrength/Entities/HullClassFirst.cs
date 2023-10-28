namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;

public class HullClassFirst : ShipHulls
{
    private const int SmallAsteroidsDamageConst = 10;
    private const int MeteoritesDamageConst = 100;
    private const int CosmoWhalesDamageConst = 100;
    private const int AntimatterFlaresDamageConst = 100;
    private const int HeatPointsDamageConst = 10;
    private const bool ShipIsActiveConst = true;
    public HullClassFirst()
    : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, CosmoWhalesDamageConst, AntimatterFlaresDamageConst, HeatPointsDamageConst, ShipIsActiveConst)
    {
    }
}