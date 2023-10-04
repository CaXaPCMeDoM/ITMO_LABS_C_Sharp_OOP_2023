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
    public static string Move(Deflectors.Entities.Deflectors deflectorsClass, ShipHulls hulls, Queue<IEnvironment> path, Collection<Engine> engineCollection, ref bool deflectorIsActive, ref bool shipIsActive, ref bool crewIsAlive)
    {
        Debug.Assert(path != null, nameof(path) + " != null");
        foreach (IEnvironment environmentForEach in path)
        {
            if (engineCollection != null)
            {
                foreach (Engine engine in engineCollection)
                {
                    if (path.Peek().EngineCompatibilityChecker(engine))
                    {
                        if (engine.MaxTravelDistance < path.Peek().Distance)
                        {
                            return "Ship Loss";
                        }
                    }
                }
            }

            bool flagMove = true;
            foreach (IObstacles obstaclesForEach in environmentForEach.ObstaclesQueue)
            {
                if (deflectorsClass != null && deflectorsClass.DeflectorIsActive && crewIsAlive &&
                    !deflectorsClass.DeflectorDamage(obstaclesForEach))
                {
                    deflectorIsActive = false;
                    crewIsAlive = false;
                    shipIsActive = false;
                    break;
                }

                if (deflectorsClass != null && deflectorsClass.DeflectorIsActive == false && crewIsAlive)
                {
                    if (hulls != null && !hulls.ShipDamage(obstaclesForEach))
                    {
                        hulls.ShipIsActive = false;
                        deflectorsClass.CrewIsAlive = false;
                    }
                }

                if (deflectorsClass != null && deflectorsClass.CrewIsAlive == false)
                {
                    crewIsAlive = false;

                    // data += "|Crew is died|";
                }
            }

            if (flagMove)
            {
            }
        }

        return "Success";
    }
}