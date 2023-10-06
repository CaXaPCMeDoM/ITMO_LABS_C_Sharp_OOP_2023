using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHullStrength.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class WalkingShuttle : ISpaceShip, ICheckFuel
{
    private readonly Deflectors.Entities.Deflectors? _deflectorsClass;
    private readonly ShipHulls _hullClassSecond;
    private readonly Deflectors.Entities.Deflectors? _photon;
    private readonly Deflectors.Entities.Deflectors? _antiNeutrinoEmitter;

    private bool _deflectorIsActive = true;
    private bool _crewIsAlive = true;
    private bool _shipIsActive = true;

    public WalkingShuttle(double maxTravelDistance, bool photonIsActive)
    {
        MaxTravelDistance = maxTravelDistance;
        ((ISegments)this).EnginesCollection.Add(new Engines.Entities.ImpulseEngineC(maxTravelDistance));
        _deflectorsClass = null;
        _hullClassSecond = new HullClassSecond();
        _antiNeutrinoEmitter = null;

        ((ISegments)this).EnginesCollection[0].StartEngine(((ISegments)this).EnginesCollection[0]);
        if (photonIsActive)
        {
            _photon = new Photon();
            _photon.DeflectorIsActive = true;
        }
        else
        {
            _photon = null;
        }
    }

    public double MaxTravelDistance { get; }
    Collection<Engine> ISegments.EnginesCollection { get; } = new Collection<Engine>();

    public int WeightShip { get; set; } = (int)WeightOverallCharacteristics.Average;

    public int Move(Queue<IEnvironment> pathShip)
    {
        return ShipMove.Move(_deflectorsClass, _hullClassSecond, pathShip, ((ISegments)this).EnginesCollection, ref _deflectorIsActive, ref _shipIsActive, ref _crewIsAlive, _photon, _antiNeutrinoEmitter);
    }

    public double CheckFuel()
    {
        double fuelReserve = 0;
        foreach (Engine engine in ((ISegments)this).EnginesCollection)
        {
            fuelReserve += engine.TotalFuelConsumptionActivePlasma + engine.TotalFuelConsumptionGravitationalMatter;
        }

        return fuelReserve;
    }
}