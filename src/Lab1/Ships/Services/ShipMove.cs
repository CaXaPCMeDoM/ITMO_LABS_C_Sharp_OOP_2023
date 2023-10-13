using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public static class ShipMove
{
    public static int Move(ISpaceShip ship, IEnumerable<IEnvironment> path)
    {
        bool crewIsAlive = true;
        bool deflectorIsActive = true;
        foreach (IEnvironment environmentForEach in path)
        {
            bool flagSuitableEnginesAreAvailable = false;
            if (ship.EnginesCollection is not null)
            {
                foreach (Engine engine in ship.EnginesCollection)
                {
                    if (environmentForEach.EngineCompatibilityChecker(engine))
                    {
                        if (engine.MaxTravelDistance < environmentForEach.Distance)
                        {
                            return (int)RouteResults.ShipIsLost;
                        }
                        else
                        {
                            engine.CalculationFuelConsumption();
                            flagSuitableEnginesAreAvailable = true;
                            break;
                        }
                    }
                }
            }

            if (flagSuitableEnginesAreAvailable == false)
            {
                return (int)RouteResults.EnginesNotSuitable;
            }

            foreach (IObstacles obstaclesForEach in environmentForEach.ObstaclesEnumerable)
            {
                if (obstaclesForEach is AntimatterFlares)
                {
                    if (ship.Photon is not null)
                    {
                        if (!ship.Photon.DeflectorDamage(obstaclesForEach))
                        {
                            return (int)RouteResults.CrewIsDead;
                        }

                        continue;
                    }
                    else
                    {
                        crewIsAlive = false;
                        return (int)RouteResults.CrewIsDead;
                    }
                }

                if (obstaclesForEach is CosmoWhales)
                {
                    if (ship.AntiNeutrinoEmitter is not null)
                    {
                        if (!ship.AntiNeutrinoEmitter.DeflectorDamage(obstaclesForEach))
                        {
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (ship.DeflectorsClass is not null)
                {
                    if (deflectorIsActive == true && crewIsAlive &&
                        !ship.DeflectorsClass.DeflectorDamage(obstaclesForEach))
                    {
                        deflectorIsActive = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (crewIsAlive && deflectorIsActive == false)
                {
                    if (ship.HullClass is not null && !ship.HullClass.ShipDamage(obstaclesForEach))
                    {
                        ship.HullClass.ShipIsActive = false;
                        return (int)RouteResults.ShipDestruction;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        return (int)RouteResults.Success;
    }
}