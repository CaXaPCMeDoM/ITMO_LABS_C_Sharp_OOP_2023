using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflector
{
    private readonly int _smallAsteroidsDamage;
    private readonly int _meteoritesDamage;
    private int _heatPoints;
    protected Deflector(int smallAsteroidsDamage, int meteoritesDamage, int heatPoints)
    {
        _smallAsteroidsDamage = smallAsteroidsDamage;
        _meteoritesDamage = meteoritesDamage;
        _heatPoints = heatPoints;
    }

    protected abstract int CosmoWhalesDamage { get; }
    protected abstract int AntimatterFlaresDamage { get; }
    public bool DeflectorDamage(IObstacles obstacles)
    {
        switch (obstacles)
        {
            case ISmallAsteroids:
                _heatPoints -= _smallAsteroidsDamage;
                break;
            case IMeteorites:
                _heatPoints -= _meteoritesDamage;
                break;
            case ICosmoWhales:
                _heatPoints -= CosmoWhalesDamage;
                break;
            case AntimatterFlares:
                _heatPoints -= AntimatterFlaresDamage;
                break;
        }

        if (_heatPoints <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}