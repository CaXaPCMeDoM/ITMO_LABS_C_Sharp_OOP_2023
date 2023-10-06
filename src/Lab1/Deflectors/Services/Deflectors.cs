using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflectors
{
    protected Deflectors(int smallAsteroidsDamage, int meteoritesDamage, int heatPoints, bool deflectorIsActive)
    {
        SmallAsteroidsDamage = smallAsteroidsDamage;
        MeteoritesDamage = meteoritesDamage;
        HeatPoints = heatPoints;
        DeflectorIsActive = deflectorIsActive;
    }

    public bool CrewIsAlive { get; set; } = true;
    public bool DeflectorIsActive { get; set; }
    protected abstract int CosmoWhalesDamage { get; }
    protected abstract int AntimatterFlaresDamage { get; }
    protected int SmallAsteroidsDamage { get; }
    protected int MeteoritesDamage { get; }
    protected int HeatPoints { get; set; }

    /*private AntimatterFlares AntimatterFlares1 { get; set; } = new AntimatterFlares
    {
        Damage = 50,
    };*/

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
            DeflectorIsActive = false;
            return false;
        }
        else
        {
            return true;
        }
    }
}