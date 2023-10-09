using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflector
{
    protected Deflector(int smallAsteroidsDamage, int meteoritesDamage, int heatPoints)
    {
        SmallAsteroidsDamage = smallAsteroidsDamage;
        MeteoritesDamage = meteoritesDamage;
        HeatPoints = heatPoints;
    }

    protected abstract int CosmoWhalesDamage { get; }
    protected abstract int AntimatterFlaresDamage { get; }
    private int SmallAsteroidsDamage { get; }
    private int MeteoritesDamage { get; }
    private int HeatPoints { get; set; }
    public bool DeflectorDamage(IObstacles obstacles)
    {
        switch (obstacles)
        {
            case SmallAsteroids:
                HeatPoints -= SmallAsteroidsDamage;
                break;
            case Meteorites:
                HeatPoints -= MeteoritesDamage;
                break;
            case CosmoWhales:
                HeatPoints -= CosmoWhalesDamage;
                break;
            case AntimatterFlares:
                HeatPoints -= AntimatterFlaresDamage;
                break;
        }

        if (HeatPoints <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}