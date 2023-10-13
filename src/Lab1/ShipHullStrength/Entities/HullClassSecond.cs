namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;

public class HullClassSecond : ShipHulls
{
    private const int SmallAsteroidsDamageConst = 4;
    private const int MeteoritesDamageConst = 10;
    private const int CosmoWhalesDamageConst = 100;
    private const int AntimatterFlaresDamageConst = 100;
    private const int HeatPointsDamageConst = 20;
    private const bool ShipIsActiveConst = true;
    public HullClassSecond()
        : base(SmallAsteroidsDamageConst, MeteoritesDamageConst, CosmoWhalesDamageConst, AntimatterFlaresDamageConst, HeatPointsDamageConst, ShipIsActiveConst)
    {
    }
}