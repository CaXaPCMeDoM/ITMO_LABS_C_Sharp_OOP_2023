namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;

public class HullClassThird : ShipHulls
{
    private const int SmallAsteroidsDamageConst = 1;
    private const int MeteoritesDamageConst = 4;
    private const int CosmoWhalesDamageConst = 100;
    private const int AntimatterFlaresDamageConst = 100;
    private const int HeatPointsDamageConst = 20;
    private const bool ShipIsActiveConst = true;
    public HullClassThird()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, CosmoWhalesDamageConst, AntimatterFlaresDamageConst, HeatPointsDamageConst, ShipIsActiveConst)
    {
    }
}