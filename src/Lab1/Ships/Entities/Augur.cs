using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;
using Itmo.ObjectOrientedProgramming.Lab1.SurroundingWorld.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : ISpaceShip
{

    private readonly Deflectors.Entities.Deflectors _deflectorsClassThird;
    private readonly ShipHulls _hullClass3;

    private bool _deflectorIsActive = true;
    private bool _crewIsAlive = true;
    private bool _shipIsActive = true;
    private string data = "|";

    public Augur(double maxTravelDistance)
    {
        ((ISegments)this).EnginesCollection.Add(new Engines.Entities.ImpulseEngineE(maxTravelDistance));
        ((ISegments)this).EnginesCollection.Add(new Engines.Entities.AlphaJumpEngine(maxTravelDistance));

        // ImpulseEngineE = new ImpulseEngineE(maxTravelDistance);
        // AlphaJumpEngine = new AlphaJumpEngine(maxTravelDistance);
        _deflectorsClassThird = new ClassThird();
        _hullClass3 = new HullClass3();

        ((ISegments)this).EnginesCollection[0].StartEngine(((ISegments)this).EnginesCollection[0]);
        ((ISegments)this).EnginesCollection[1].StartEngine(((ISegments)this).EnginesCollection[1]);

        // DeflectorsClass3.DeflectorDamage(new Meteorites());
        // AlphaJumpEngine.StartEngine(AlphaJumpEngine);
        // ImpulseEngineE.StartEngine(ImpulseEngineE);
    }

    Queue<IEnvironment> ISegments.Path { get; } = new Queue<IEnvironment>();
    Collection<Engine> ISegments.EnginesCollection { get; } = new Collection<Engine>();

    // protected readonly Engine ImpulseEngineE;
    // protected readonly Engine AlphaJumpEngine;
    public int WeightShip { get; set; } = (int)WeightOverallCharacteristics.Big;

    public void AddPathShip(IEnvironment environment)
    {
        ((ISpaceShip)this).Path.Enqueue(environment);
    }

    public string Move()
    {
        ShipMove.Move(_deflectorsClassThird, _hullClass3, ((ISpaceShip)this).Path,  ((ISegments)this).EnginesCollection, ref _deflectorIsActive, ref _shipIsActive, ref _crewIsAlive);
        /*foreach (IEnvironment environmentForEach in ((ISpaceShip)this).Path)
        {
            if()
            bool flagMove = true;
            foreach (IObstacles obstaclesForEach in environmentForEach.ObstaclesQueue)
            {
                if (_deflectorsClassThird.DeflectorIsActive && _crewIsAlive && !_deflectorsClassThird.DeflectorDamage(obstaclesForEach))
                {
                    _deflectorIsActive = false;
                    _crewIsAlive = false;
                    _shipIsActive = false;
                    break;
                }

                if (_deflectorsClassThird.DeflectorIsActive == false && _crewIsAlive)
                {
                    if (!_hullClass3.ShipDamage(obstaclesForEach))
                    {
                        _hullClass3.ShipIsActive = false;
                        _deflectorsClassThird.CrewIsAlive = false;
                    }
                }

                if (_deflectorsClassThird.CrewIsAlive == false)
                {
                    _crewIsAlive = false;

                    // data += "|Crew is died|";
                }
            }

            if (flagMove)
            {

            }
        }*/

        return data;
    }

    public IEnvironment GetPathShip()
    {
        return ((ISpaceShip)this).Path.Dequeue();
    }

    public void CheckFuel()
    {
        double fuelReserve = ImpulseEngineE.TotalFuelConsumption;
        Console.WriteLine($"Топливный резерв: {fuelReserve}");
    }
}