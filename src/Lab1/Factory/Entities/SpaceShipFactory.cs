using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Factory.Entities;

public static class SpaceShipFactory
{
    public static ISpaceShip? CreateSpaceShip(string shipName, double maxTravelDistance, bool photonIsActive)
    {
        ISpaceShip? ship = shipName switch
        {
            nameof(Augur) => new Augur(maxTravelDistance, photonIsActive),
            nameof(Meredian) => new Meredian(maxTravelDistance, photonIsActive),
            nameof(Stella) => new Stella(maxTravelDistance, photonIsActive),
            nameof(Vaclas) => new Vaclas(maxTravelDistance, photonIsActive),
            nameof(WalkingShuttle) => new WalkingShuttle(maxTravelDistance, photonIsActive),
            _ => null,
        };
        return ship;
    }
}