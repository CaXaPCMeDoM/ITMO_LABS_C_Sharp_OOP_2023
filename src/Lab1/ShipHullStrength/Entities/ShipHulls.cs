using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;

public abstract class ShipHulls
{
    protected ShipHulls(int smallAsteroidsDamage, int meteoritesDamage, int cosmoWhalesDamage, int antimatterFlaresDamage, int heatPoints, bool shipIsActive)
    {
        SmallAsteroidsDamage = smallAsteroidsDamage;
        MeteoritesDamage = meteoritesDamage;
        CosmoWhalesDamage = cosmoWhalesDamage;
        AntimatterFlaresDamage = antimatterFlaresDamage;
        HeatPoints = heatPoints;
        ShipIsActive = shipIsActive;
    }

    public bool ShipIsActive { get; protected internal set; }
    private double HeatPoints { get; set; }
    private double AntimatterFlaresDamage { get; }
    private double CosmoWhalesDamage { get; }
    private double MeteoritesDamage { get; }
    private double SmallAsteroidsDamage { get; }

    public bool ShipDamage(IObstacles obstacles)
    {
        switch (obstacles)
        {
            case ISmallAsteroids:
                HeatPoints -= SmallAsteroidsDamage;
                break;
            case IMeteorites:
                HeatPoints -= MeteoritesDamage;
                break;
            case IAntimatterFlares:
                HeatPoints -= AntimatterFlaresDamage;
                break;
            case ICosmoWhales:
                HeatPoints -= CosmoWhalesDamage;
                break;
        }

        return !(HeatPoints < 0);
    }
}