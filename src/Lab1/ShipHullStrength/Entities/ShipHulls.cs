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
    private double AntimatterFlaresDamage { get; set; }
    private double CosmoWhalesDamage { get; set; }
    private double MeteoritesDamage { get; set; }
    private double SmallAsteroidsDamage { get; set; }

    public bool ShipDamage(IObstacles obstacles)
    {
        switch (obstacles)
        {
            case SmallAsteroids:
                HeatPoints -= SmallAsteroidsDamage;
                break;
            case Meteorites:
                HeatPoints -= MeteoritesDamage;
                break;
            case AntimatterFlares:
                HeatPoints -= AntimatterFlaresDamage;
                break;
            case CosmoWhales:
                HeatPoints -= CosmoWhalesDamage;
                break;
        }

        return !(HeatPoints < 0);
    }
}