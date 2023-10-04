using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class BaseSpaceShip : ISpaceShip
{
    private bool _deflectorIsActive = true;
    private bool _crewIsAlive = true;
    private bool _shipIsActive = true;
    private string data = "|";

    protected BaseSpaceShip(Collection<Engine> enginesCollection, Queue<IEnvironment> path)
    {
        EnginesCollection = enginesCollection;
        ((ISpaceShip)this).Path = path;
    }

    Queue<IEnvironment> ISegments.Path { get; } = new Queue<IEnvironment>();
    public Collection<Engine> EnginesCollection { get; }
    public void CheckFuel()
    {
        foreach (Engine engineForEach in EnginesCollection)
        {
            if (engineForEach is ImpulseEngine)
            {
                double fuelReserve = engineForEach.TotalFuelConsumption;
                Console.WriteLine($"Топливный резерв: {fuelReserve}");
            }
        }
    }

    public void AddPathShip(IEnvironment environment)
    {
        ((ISpaceShip)this).Path.Enqueue(environment);
    }

    public string Move(Deflectors.Entities.Deflectors deflectorsClass, ShipHulls hulls)
    {
        foreach (IEnvironment environmentForEach in ((ISpaceShip)this).Path)
        {
            bool flagMove = true;
            foreach (IObstacles obstaclesForEach in environmentForEach.ObstaclesQueue)
            {
                if (deflectorsClass != null && deflectorsClass.DeflectorIsActive && _crewIsAlive && !deflectorsClass.DeflectorDamage(obstaclesForEach))
                {
                    _deflectorIsActive = false;
                    _crewIsAlive = false;
                    _shipIsActive = false;
                    break;
                }

                if (deflectorsClass != null && deflectorsClass.DeflectorIsActive == false && _crewIsAlive)
                {
                    if (hulls != null && !hulls.ShipDamage(obstaclesForEach))
                    {
                        hulls.ShipIsActive = false;
                        deflectorsClass.CrewIsAlive = false;
                    }
                }

                if (deflectorsClass != null && deflectorsClass.CrewIsAlive == false)
                {
                    _crewIsAlive = false;

                    // data += "|Crew is died|";
                }
            }

            if (flagMove)
            {

            }
        }

        return data;
    }
}