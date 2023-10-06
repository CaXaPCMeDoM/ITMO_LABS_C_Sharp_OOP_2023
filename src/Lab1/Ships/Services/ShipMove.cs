using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public static class ShipMove
{
    public static int Move(Deflectors.Entities.Deflectors? deflectorsClass, ShipHulls hulls, Queue<IEnvironment> path, Collection<Engine> engineCollection, ref bool deflectorIsActive, ref bool shipIsActive, ref bool crewIsAlive, Deflectors.Entities.Deflectors? photon, Deflectors.Entities.Deflectors? antiNeutrinoEmitter)
    {
        Debug.Assert(path != null, nameof(path) + " != null");
        foreach (IEnvironment environmentForEach in path)
        {
            bool flagSuitableEnginesAreAvailable = false;
            if (engineCollection != null)
            {
                foreach (Engine engine in engineCollection)
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

            foreach (IObstacles obstaclesForEach in environmentForEach.ObstaclesQueue)
            {
                if (obstaclesForEach is AntimatterFlares)
                {
                    if (photon is not null)
                    {
                        if (!photon.DeflectorDamage(obstaclesForEach))
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
                    if (antiNeutrinoEmitter != null)
                    {
                        if (!antiNeutrinoEmitter.DeflectorDamage(obstaclesForEach))
                        {
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (deflectorsClass is not null)
                {
                    if (deflectorsClass is { DeflectorIsActive: true } && crewIsAlive &&
                        !deflectorsClass.DeflectorDamage(obstaclesForEach))
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
                    if (hulls != null && !hulls.ShipDamage(obstaclesForEach))
                    {
                        shipIsActive = false;
                        hulls.ShipIsActive = false;
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